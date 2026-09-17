using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;

    public void Interact(Player player)
    {
        door.DoorToggle();
    }
}
