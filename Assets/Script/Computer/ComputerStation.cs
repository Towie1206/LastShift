using UnityEngine;

public class ComputerStation : MonoBehaviour, IInteractable
{
    [SerializeField] private ComputerSequence computerSequence;
    public void Interact(Player player)
    {
        computerSequence.Play();
    }

    
}
