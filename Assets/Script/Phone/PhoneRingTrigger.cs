using System.Reflection.Metadata;
using UnityEngine;

public class PhoneRingTrigger : MonoBehaviour
{
    [SerializeField] private PhoneStation phoneStation;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private DialogueData data;
    [SerializeField] private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.EnterDialogue();
            phoneStation.StartRinging();
            gameObject.SetActive(false);
            dialogueController.Play(data);
        }    
    }

    private void OnEnable()
    {
        dialogueController.Completed += HandleEnd;
    }

    private void OnDisable()
    {
        dialogueController.Completed -= HandleEnd;
    }

    private void HandleEnd()
    {
        player.ExitDialogue();
    }
}
