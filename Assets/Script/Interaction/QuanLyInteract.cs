using System;
using UnityEngine;

public class QuanLyInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;
    [SerializeField] private Player player;

    [Header("Dich chuyen & Bat dau ca truc")]
    [SerializeField] private Transform securityRoomSpawnPoint;
    [SerializeField] private ShiftClock clock;
    [SerializeField] private AnomalyManager anomalyManager;
    [SerializeField] private GeneratorSystem generatorSystem;

    private void Start()
    {
        clock.enabled = false;
    }
    public void Interact()
    {
        controller.Completed += HandleDialogueCompleted;
        
        player.EnterDialogue();
        controller.Play(data);
    }

    private void HandleDialogueCompleted()
    {
        controller.Completed -= HandleDialogueCompleted;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = securityRoomSpawnPoint.position;
            rb.rotation = securityRoomSpawnPoint.rotation;

            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            player.transform.position = securityRoomSpawnPoint.position;
            player.transform.rotation = securityRoomSpawnPoint.rotation;
        }

        OfficeViewManager viewManager = player.GetComponent<OfficeViewManager>();
        if (viewManager != null)
        {
            viewManager.ResetToFront();
        }

        player.EnterOffice();

        clock.enabled = true;
        anomalyManager.StartShift();
        generatorSystem.StartGeneratorAfterDelay(45f);
    }
}
