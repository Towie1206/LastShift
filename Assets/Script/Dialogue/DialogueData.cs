using UnityEngine;

[CreateAssetMenu(
fileName = "D_NewDialogue",
menuName = "Dialogue/Dialogue Data"
)]
public class DialogueData : ScriptableObject
{
    [Header("Dialogue Content (Tiếng Việt)")]
    [SerializeField, TextArea(2,5)]
    private string[] lines;

    [Header("Dialogue Content (English)")]
    [SerializeField, TextArea(2,5)]
    private string[] lines_en;

    public int LineCount => lines == null ? 0 : lines.Length;

    public string GetLine(int index) { 
        if (LanguageManager.IsEnglish && lines_en != null && index < lines_en.Length && !string.IsNullOrEmpty(lines_en[index]))
            return lines_en[index];
        return lines[index]; 
    }
}