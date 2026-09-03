using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerChatView : MonoBehaviour
{
    [SerializeField] private GameObject computerUI;
    [SerializeField] private GameObject managerChatRoot;
    [SerializeField] private TMP_Text chatHistoryText;
    [SerializeField] private TMP_Text draftMessageText;
    [SerializeField] private Button sendButton;
    [SerializeField] private GameObject typingIndicator;
    [SerializeField] private Button continueButton;

    public event Action SendRequested;
    public event Action ContinueRequested;

    private void OnEnable()
    {
        sendButton.onClick.AddListener(HandleSendClicked);
        continueButton.onClick.AddListener(HandleContinueClicked);
    }

    private void OnDisable()
    {
        sendButton.onClick.RemoveListener(HandleSendClicked);
        continueButton.onClick.RemoveListener(HandleContinueClicked);
    }
    public void Show()
    {
        computerUI?.SetActive(true);
        managerChatRoot?.SetActive(true);
    }

    public void Hide()
    {
        computerUI?.SetActive(false);
    }

    public void ClearHistory()
    {
        chatHistoryText.text = string.Empty;
    }

    public void SetDraft(string message)
    {
        draftMessageText.text = message;
    }

    public void AddPlayerMessage(string message)
    {
        AppendMessage("Bạn", message);
    }

    public void AddManagerMessage(string message)
    {
        AppendMessage("Quản lý", message);
    }

    private void AppendMessage(string sender, string message)
    {
        if (!string.IsNullOrEmpty(chatHistoryText.text))
        {
            chatHistoryText.text += "\n\n";
        }

        chatHistoryText.text += $"<b>{sender}:</b> {message}";
    }

    public void SetSendInteractable(bool value)
    {
        sendButton.interactable = value;
    }

    public void ShowTyping(bool value)
    {
        typingIndicator.SetActive(value);
    }

    public void ShowContinue(bool value)
    {
        continueButton.gameObject.SetActive(value);
    }
    private void HandleSendClicked()
    {
        SendRequested?.Invoke();
    }

    private void HandleContinueClicked()
    {
        ContinueRequested?.Invoke();
    }

}
