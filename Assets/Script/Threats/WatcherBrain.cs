using UnityEngine;

public class WatcherBrain : MonoBehaviour
{
    [SerializeField] private WatcherObservation observation;
    [SerializeField] private WatcherRoaming roaming;
    [SerializeField] private WatcherMovement movement;
    [SerializeField] private WatcherLocation attackLocation;
    [SerializeField] private WatcherAttack attack;

    [SerializeField, Min(1)]
    private int threatLevelRequiredAttack = 4;

    private float threatLevel;

    private void OnEnable()
    {
        observation.IgnoredTooLong += HandleIgnoredTooLong;
        attack.Blocked += HandleAttackBlocked;
    }
    private void OnDisable()
    {
        observation.IgnoredTooLong -= HandleIgnoredTooLong;
        attack.Blocked -= HandleAttackBlocked;
    }

    private void HandleIgnoredTooLong()
    {
        ProcessThreatTrigger(.5f);
    }

    [ContextMenu("test wrong response")]
    private void ReportWrongResponse()
    {
        ProcessThreatTrigger(1);
    }

    private void ProcessThreatTrigger(float threatAmount)
    {
        WatcherLocation currentLocation =
            movement.GetCurrentLocation();

        if (currentLocation != null &&
            currentLocation.IsAttackLocation())
        {
            return;
        }

        threatLevel += threatAmount;

        if (threatLevel >= threatLevelRequiredAttack)
        {
            movement.MoveTo(attackLocation);
            attack.BeginAttack();
            return;
        }

        roaming.Roam();
    }

    private void HandleAttackBlocked()
    {
        threatLevel = Mathf.Max(0f, threatLevel - 1f);
        roaming.Roam();
    }
}
