using UnityEngine;

public class LightControl : MonoBehaviour, IInteractable
{
    [SerializeField] private ToggleLight light;

    public void Interact(Player player)
    {
        light.LightControl();
    }
}
