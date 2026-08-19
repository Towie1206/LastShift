using UnityEngine;

public class WatcherBrain : MonoBehaviour
{
    [SerializeField] private WatcherObservation observation;
    [SerializeField] private WatcherRoaming roaming;
    [SerializeField] private WatcherMovement movement;
    [SerializeField] private WatcherLocation attackLocation;

    [SerializeField, Min(1)]
    private int threatLevelRequiredAttack = 4;

    private float threatLevel;

    private void OnEnable()
    {
        observation.IgnoredTooLong += HandleIgnoredTooLong;
    }
    private void OnDisable()
    {
        observation.IgnoredTooLong -= HandleIgnoredTooLong;
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
        threatLevel += threatAmount;

        if (threatLevel >= threatLevelRequiredAttack)
        {
            movement.MoveTo(attackLocation);
            return;
        }

        roaming.Roam();
    }
}
