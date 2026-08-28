using UnityEngine;

public class PictureFrame : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;
    [SerializeField] private Player player;

    public void Interact()
    {
        player.EnterDialogue();
        controller.Play(data);
    }

}
