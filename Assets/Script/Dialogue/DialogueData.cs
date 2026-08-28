using UnityEngine;

[CreateAssetMenu(
fileName = "D_NewDialogue",
menuName = "Dialogue/Dialogue Data"
)]
public class DialogueData : ScriptableObject
{
    [Header("Dialogue Content")]
    [SerializeField, TextArea(2,5)]
    private string[] lines;

    public int LineCount => lines == null ? 0 : lines.Length;

    public string GetLine(int index) { return lines[index]; }
}