using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private Vector3 openPos;
    [SerializeField] private Vector3 closePos;
    [SerializeField] private float speed;
    [SerializeField] bool isOpen;
    [SerializeField] bool isOn;

    private void Start()
    {
        transform.localPosition = isOpen ? openPos : closePos;
    }

    private void Update()
    {
        DoorControl();
        LightControl();
    }

    private void DoorControl()
    {
        Vector3 targetPos = isOpen ? openPos : closePos;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);

    }
    private void LightControl()
    {
        Light.SetActive(isOn);
    }
    public void DoorToggle()
    {
        isOpen = !isOpen;
    }
    public void LightToggle()
    {
        isOn = !isOn;
    }

    public bool IsFullyClosed()
    {
        float distanceToClosedPosition = Vector3.Distance(transform.localPosition, closePos);
        
        return distanceToClosedPosition <= 0.01f;
    }

}
