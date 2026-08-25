using UnityEngine;

public class CameraLocation : MonoBehaviour
{
    [SerializeField] private AnomalyLocation location;

    public AnomalyLocation Location
    {
        get { return location; }
    }
}
