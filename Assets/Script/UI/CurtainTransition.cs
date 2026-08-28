using System.Collections;
using UnityEngine;

public class CurtainTransition : MonoBehaviour
{
    [SerializeField] private RectTransform upperLid;
    [SerializeField] private RectTransform lowerLid;
    [SerializeField] private float moveDuration = 1.5f;
    public IEnumerator OpenEyes()
    {
        Vector3 targetPos0 = new Vector3(0, -810, 0);
        Vector3 targetPos1 = new Vector3(0, 810, 0);
        Vector3 startPos0 = lowerLid.localPosition;
        Vector3 startPos1 = upperLid.localPosition;

        float timer = 0;
        while (timer < moveDuration)
        {
            float t = timer / moveDuration;
            lowerLid.localPosition = Vector3.Lerp(startPos0, targetPos0, t);
            upperLid.localPosition = Vector3.Lerp(startPos1, targetPos1, t);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
