using UnityEngine;

public class PictureFrame : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;

    public void Interact(Player player)
    {
        controller.Play(data);
    }
}
