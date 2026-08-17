using UnityEngine;

public class WatcherLocation : MonoBehaviour
{
    [SerializeField] private bool isAttackLocation;

    public bool IsAttackLocation()
    {
        return isAttackLocation;
    }
}
