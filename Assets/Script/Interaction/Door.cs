using UnityEngine;

public class Door : MonoBehaviour, IPowerConsumer
{
    [SerializeField] private Vector3 openPos;
    [SerializeField] private Vector3 closePos;
    [SerializeField] private float speed;
    [SerializeField] private float doorDrainRate = 1f;
    private bool isOpen = true;

    public bool IsConsumingPower => !isOpen;

    public float PowerDrainRate => doorDrainRate;

    public bool DoorCheck() => isOpen;

    private void Start()
    {
        transform.localPosition = isOpen ? openPos : closePos;

    }

    private void Update()
    {
        DoorControl();
    }

    private void DoorControl()
    {
        Vector3 targetPos = isOpen ? openPos : closePos;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);

    }

    public void DoorToggle()
    {
        isOpen = !isOpen;
    }

    public bool IsFullyClosed()
    {
        float distanceToClosedPosition = Vector3.Distance(transform.localPosition, closePos);
        
        return distanceToClosedPosition <= 0.01f;
    }

    public void ForceOpen() => isOpen = true;

}
