using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Player player;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public RectTransform[] rectTransforms;
    public float moveDuration = 2.5f;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typeline());
    }
    IEnumerator Typeline()
    {
        //Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            StartCoroutine(OpenEyes());
        }
    }

    IEnumerator OpenEyes()
    {
        Vector3 startPos0 = rectTransforms[0].localPosition;
        Vector3 startPos1 = rectTransforms[1].localPosition;
        Vector3 targetPos0 = new Vector3(0, -810, 0);
        Vector3 targetPos1 = new Vector3(0, 810, 0);

        float timer = 0;
        while (timer < moveDuration)
        {
            float t = timer / moveDuration;
            rectTransforms[0].localPosition = Vector3.Lerp(startPos0, targetPos0, t);
            rectTransforms[1].localPosition = Vector3.Lerp(startPos1, targetPos1, t);

            timer += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}