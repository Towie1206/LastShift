using UnityEngine;

public class PictureFrame : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;
    [SerializeField] private Player player;

    public void Interact()
    {
        controller.Completed += HandleDialogueCompleted;

        player.EnterDialogue();
        controller.Play(data);
    }

    private void HandleDialogueCompleted()
    {
        controller.Completed -= HandleDialogueCompleted;
        player.ExitDialogue();
    }
}
