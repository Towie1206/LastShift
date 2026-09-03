using System;
using System.Collections;
using UnityEngine;

public enum ChatPhase
{
    NotStarted,
    ReadyToSend,
    WaitingForReply,
    Finished,
    Ending
}

public class ManagerChatController : MonoBehaviour
{
    [SerializeField] private ManagerChatView chatView;
    [SerializeField] private ManagerChatData chatData;
    private int currentIndex;
    private Coroutine ReplyCo;
    private ChatPhase currentPhase = ChatPhase.NotStarted;
    public event Action Completed;

    private void OnEnable()
    {
        chatView.SendRequested += HandleSendRequested;
        chatView.ContinueRequested += HandleContinueRequested;
    }

    private void OnDisable()
    {
        chatView.SendRequested -= HandleSendRequested;
        chatView.ContinueRequested -= HandleContinueRequested;
    }

    public void Play()
    {
        currentIndex = 0;

        chatView.Show();
        chatView.ClearHistory();
        chatView.ShowTyping(false);
        chatView.ShowContinue(false);

        PrepareCurrentTurn();
    }

    private void PrepareCurrentTurn()
    {
        ManagerChatTurn chatTurn = chatData.GetTurn(currentIndex);

        chatView.SetDraft(chatTurn.PlayerMessage);
        chatView.SetSendInteractable(true);

        currentPhase = ChatPhase.ReadyToSend;
    }

    private void HandleSendRequested()
    {
        if (currentPhase != ChatPhase.ReadyToSend)
        {
            return;
        }
        ManagerChatTurn chatTurn = chatData.GetTurn(currentIndex);
        currentPhase = ChatPhase.WaitingForReply;
        chatView.SetSendInteractable(false);
        chatView.AddPlayerMessage(chatTurn.PlayerMessage);
        chatView.SetDraft(string.Empty);
        ReplyCo = StartCoroutine(ShowManagerReplies(chatTurn));
    }

    private void HandleContinueRequested()
    {
        if(currentPhase != ChatPhase.Finished)
        {
            return;
        }

        currentPhase = ChatPhase.Ending;
        chatView.ShowContinue(false);
        Completed?.Invoke();
    }

    private IEnumerator ShowManagerReplies(ManagerChatTurn turn)
    {
        for (int i = 0; i < turn.ReplyCount; i++)
        {
            ManagerChatReply reply = turn.GetReply(i);
            chatView.ShowTyping(true);
            yield return new WaitForSeconds(reply.DelayBefore);

            chatView.ShowTyping(false);
            chatView.AddManagerMessage(reply.Message);
        }
        ReplyCo = null;
        AdvanceTurn();
    }

    private void AdvanceTurn()
    {
        currentIndex++;
        if(currentIndex >= chatData.TurnCount)
        {
            currentPhase = ChatPhase.Finished;
            chatView.SetDraft(string.Empty);
            chatView.SetSendInteractable(false);
            chatView.ShowTyping(false);
            chatView.ShowContinue(true);
            return;
        }

        PrepareCurrentTurn();
    }
}
