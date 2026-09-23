using System;
using UnityEngine;

public class QuanLyInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueData data;
    [SerializeField] private DialogueController controller;
    [SerializeField] private Player player;

    public event Action OnDialogueCompleted;
    public void Interact(Player player)
    {
        if (this.player == null) this.player = player;
        controller.Completed += HandleDialogueCompleted;
        controller.Play(data);
    }
    private void HandleDialogueCompleted()
    {
        controller.Completed -= HandleDialogueCompleted;
        // Nói chuyện xong -> Chỉ việc phát tín hiệu, không cần làm gì thêm!
        OnDialogueCompleted?.Invoke();
    }
}
