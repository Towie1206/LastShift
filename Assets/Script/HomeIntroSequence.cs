using UnityEngine;

public class HomeIntroSequence : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private DialogueData data;
    [SerializeField] private CurtainTransition curtainTransition;

    private Coroutine coroutine;

    private void Start()
    {
        dialogueController.Completed += HandleCompletedIntro;
        player.EnterDialogue();
        dialogueController.Play(data);
    }

    private void HandleCompletedIntro()
    {
        dialogueController.Completed -= HandleCompletedIntro;
        coroutine = StartCoroutine(curtainTransition.OpenEyes());
        player.ExitDialogue();
    }
}
