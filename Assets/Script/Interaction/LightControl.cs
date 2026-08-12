using UnityEngine;

public class LightControl : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;

    public void Interact()
    {
        door.LightToggle();
    }
}
