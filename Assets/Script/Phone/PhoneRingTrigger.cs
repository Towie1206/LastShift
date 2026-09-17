using System.Reflection.Metadata;
using UnityEngine;

public class PhoneRingTrigger : MonoBehaviour
{
    [SerializeField] private PhoneStation phoneStation;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private DialogueData data;
    private bool hasTriggered = false;
    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (hasTriggered) return;
            collider.enabled = false;
            hasTriggered = true;
            dialogueController.Completed += HandleEnd;
            phoneStation.StartRinging();
            dialogueController.Play(data);
        }    
    }

    private void HandleEnd()
    {
        dialogueController.Completed -= HandleEnd;
        gameObject.SetActive(false);
    }
}
