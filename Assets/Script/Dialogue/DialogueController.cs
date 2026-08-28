using System;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueView view;
    private DialogueData currentData;

    private bool isRunning;
    private int currentLineIndex;
    public event Action Completed;

    public void Play(DialogueData data)
    {
        if (data == null || data.LineCount == 0) return;

        currentData = data;
        isRunning = true;
        currentLineIndex = 0;
        view.Show();
        view.TypeLine(currentData.GetLine(currentLineIndex));
    }

    public void Advance()
    {
        if (!isRunning)
        {
            return;
        }
        if (view.IsTyping)
        {
            view.RevealCurrentLine();
            return;
        }

        currentLineIndex++;

        if (currentLineIndex >= currentData.LineCount)
        {
            Complete();
            return;
        }

        view.TypeLine(currentData.GetLine(currentLineIndex));
    }

    private void Complete()
    {
        if (!isRunning)
        {
            return;
        }
        isRunning = false;
        view.Hide();
        currentData = null;
        currentLineIndex = 0;
        Completed?.Invoke();
    }
}
