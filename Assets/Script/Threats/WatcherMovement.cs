using UnityEngine;

public class WatcherMovement : MonoBehaviour
{
    [SerializeField] private WatcherLocation startingLocation;

    [SerializeField] private Animator anim;

    private WatcherLocation currentLocation;

    private void Start()
    {
        MoveTo(startingLocation);
    }

    public void MoveTo(WatcherLocation location)
    {
        if (location == null) return;
        // 1. Dịch chuyển quái vật đến điểm mới
        transform.SetPositionAndRotation(location.transform.position, location.transform.rotation);

        // 2. Ép quái vật diễn đúng cái dáng của phòng đó
        if (anim != null && !string.IsNullOrEmpty(location.poseAnimationName))
        {
            anim.Play(location.poseAnimationName);
        }

        currentLocation = location;
    }

    public WatcherLocation GetCurrentLocation()
    {
        return currentLocation;
    }

}
