using System;
using UnityEngine;

public class QuanLyInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;
    [SerializeField] private Player player;

    [Header("Dịch chuyển & Bắt đầu ca trực")]
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
            // Ép vị trí và góc xoay bằng Rigidbody
            rb.position = securityRoomSpawnPoint.position;
            rb.rotation = securityRoomSpawnPoint.rotation;

            // Xóa sạch quán tính để Player không bị trượt đi
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            player.transform.position = securityRoomSpawnPoint.position;
            player.transform.rotation = securityRoomSpawnPoint.rotation;
        }

        player.ExitDialogue();

        clock.enabled = true;
        anomalyManager.StartShift();
        generatorSystem.StartGeneratorAfterDelay(45f);
    }
}
