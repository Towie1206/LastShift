using System;
using UnityEngine;

public class WatcherObservation : MonoBehaviour
{
    [SerializeField] private WatcherMovement movement;
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private CCTVView cctvView;
    [SerializeField] private WatcherAttack attack;
    [SerializeField] private float ignoredDuration = 15f;
    [SerializeField] private float ignoredDurationReduction = 2f;
    [SerializeField] private float minimumIgnoredDuration = 7f;

    private float ignoredTimer;
    public event Action IgnoredTooLong;

    private void OnEnable()
    {
        attack.Blocked += HandleAttackBlocked;
    }

    private void OnDisable()
    {
        attack.Blocked -= HandleAttackBlocked;
    }

    private void Update()
    {

        WatcherLocation currentLocation = movement.GetCurrentLocation();
        if(currentLocation.IsAttackLocation())
        {
            ignoredTimer = 0;
            return;
        }
        if(IsObserved(currentLocation))
        {
            ignoredTimer = 0;
            return;
        }

        ignoredTimer += Time.deltaTime;

        if (ignoredTimer < ignoredDuration)
            return;

        ignoredTimer = 0f;
        IgnoredTooLong?.Invoke();
    }

    private bool IsObserved(WatcherLocation currentLocation)
    {
        if (!cctvView.isVisible())
            return false;

        return cameraSystem.currentCamIndex == currentLocation.GetCameraIndex();
    }

    private void HandleAttackBlocked()
    {
        ShortenIgnoredDuration(ignoredDurationReduction);
        ignoredTimer = 0f;
    }

    private void ShortenIgnoredDuration(float amount)
    {
        ignoredDuration = Mathf.Max(minimumIgnoredDuration,ignoredDuration - amount);
    }

}
