using UnityEngine;

public class WatcherMovement : MonoBehaviour
{
    [SerializeField] private WatcherLocation startingLocation;

    private WatcherLocation currentLocation;

    private void Awake()
    {
        MoveTo(startingLocation);
    }
    
    public void MoveTo(WatcherLocation location)
    {
        if(location == null) return;

        transform.SetPositionAndRotation(location.transform.position, location.transform.rotation);

        currentLocation = location;
    }    

    public WatcherLocation GetCurrentLocation()
    {
        return currentLocation; 
    }

}
