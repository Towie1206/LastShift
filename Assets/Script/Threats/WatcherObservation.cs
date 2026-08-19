using System;
using UnityEngine;

public class WatcherObservation : MonoBehaviour
{
    [SerializeField] private WatcherMovement movement;
    [SerializeField] private CameraSystem cameraSystem;
    [SerializeField] private CCTVView cctvView;
    [SerializeField] private float ignoredDuration = 15f;

    private float ignoredTimer;
    public event Action IgnoredTooLong;

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

}
