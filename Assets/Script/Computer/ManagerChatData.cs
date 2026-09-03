using UnityEngine;

[System.Serializable]
public class ManagerChatReply
{
    [SerializeField, TextArea(2, 5)] private string message;
    [SerializeField, TextArea(2, 5)] private string message_en;
    [SerializeField, Min(0f)] private float delayBefore;
    public string Message => LanguageManager.IsEnglish && !string.IsNullOrEmpty(message_en) ? message_en : message;
    public float DelayBefore => delayBefore;
}
[System.Serializable]
public class ManagerChatTurn
{
    [SerializeField] private string playerMessage;
    [SerializeField] private string playerMessage_en;
    [SerializeField] private ManagerChatReply[] managerReplies;

    public string PlayerMessage => LanguageManager.IsEnglish && !string.IsNullOrEmpty(playerMessage_en) ? playerMessage_en : playerMessage;

    public int ReplyCount => managerReplies == null ? 0 : managerReplies.Length;

    public ManagerChatReply GetReply(int index) => managerReplies[index];
}

[CreateAssetMenu(fileName = "D_NewChat")]
public class ManagerChatData : ScriptableObject
{
    [SerializeField] private ManagerChatTurn[] turns;
    public int TurnCount => turns == null ? 0 : turns.Length;

    public ManagerChatTurn GetTurn(int index) => turns[index];
}
