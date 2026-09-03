using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private Image dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueBoxText;
    [SerializeField] private float textSpeed = 0.02f;

    private bool isTyping;
    private Coroutine typewriter;

    private void Awake()
    {
        Hide();
    }

    public void Hide()
    {
        StopTyping();
        dialogueBox.gameObject.SetActive(false);
        dialogueBoxText.text = string.Empty;
    }

    public void Show()
    {
        StopTyping();
        dialogueBox.gameObject.SetActive(true);
        dialogueBoxText.text = string.Empty;
    }

    private void StopTyping()
    {
        if (typewriter != null)
        {
            StopCoroutine(typewriter);
            typewriter = null;
        }
            isTyping = false;
    }

    public void TypeLine(string text)
    {
        StopTyping();

        if (text == null)
            text = string.Empty;

        dialogueBoxText.text = string.Empty;

        isTyping = true;

        typewriter = StartCoroutine(TypeWriter(text));

    }

    private IEnumerator TypeWriter(string text)
    {
        dialogueBoxText.text = text;
        dialogueBoxText.maxVisibleCharacters = 0;

        dialogueBoxText.ForceMeshUpdate();

        int characterCount = dialogueBoxText.textInfo.characterCount;

        for(int i = 0; i < characterCount;  i++)
        {
            dialogueBoxText.maxVisibleCharacters += 1;
            yield return new WaitForSeconds(textSpeed);
        }

        typewriter = null;
        isTyping = false;
    }

    public void RevealCurrentLine()
    {
        StopTyping();
        dialogueBoxText.maxVisibleCharacters = int.MaxValue;
    }

    public bool IsTyping
    {
        get { return isTyping; }
    }
}
