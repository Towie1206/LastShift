using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;

    public void Interact()
    {
        door.DoorToggle();
    }
}
