using System.Collections.Generic;
using UnityEngine;

public class WatcherRoaming : MonoBehaviour
{
    [SerializeField] private WatcherMovement movement;
    [SerializeField] private WatcherLocation[] roamingLocations;

    [ContextMenu("Test roam")]
    public void Roam()
    {
        WatcherLocation nextLocation = SelectRandomLocation();

        if (nextLocation == null)
            return;

        movement.MoveTo(nextLocation);
    }

    private WatcherLocation SelectRandomLocation()
    {
        List<WatcherLocation> availableLocations =
            new List<WatcherLocation>();

        WatcherLocation currentLocation =
            movement.GetCurrentLocation();

        foreach (WatcherLocation location in roamingLocations)
        {
            if (location == null)
                continue;

            if (location == currentLocation)
                continue;

            if (location.IsAttackLocation())
                continue;

            availableLocations.Add(location);
        }

        if (availableLocations.Count == 0)
            return null;

        int randomIndex =
            Random.Range(0, availableLocations.Count);

        return availableLocations[randomIndex];
    }
}
