using System.Collections;
using UnityEngine;
public class LetterStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Player player;

    private Collider letterCollider;

    private float moveDuration = .75f;
    private Coroutine moveCo;
    private Transform originalParent;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    private bool isReading;

    private void Awake()
    {
        letterCollider = GetComponent<Collider>();
    }

    public void Interact()
    {
        player.OpenLetter(this);
    }

    public void PickUp(Transform holdPoint)
    {
        if (isReading || holdPoint == null)
            return;

        originalParent = transform.parent;
        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;
    
        if (moveCo != null)
            StopAllCoroutines();
        moveCo = StartCoroutine(MoveToHoldPoint(holdPoint));

        letterCollider.enabled = false;

        isReading = true;
    }

    public void PutBack()
    {
        if (!isReading)
            return;

        if (moveCo != null)
            StopCoroutine(moveCo);
        moveCo = StartCoroutine(MoveBack());

        letterCollider.enabled = true;

        isReading = false;
    }

    private IEnumerator MoveToHoldPoint(Transform holdPoint)
    {
        float timer = 0;
        transform.SetParent(holdPoint, true);
        Vector3 startPosition = transform.localPosition;
        Quaternion startRotation = transform.rotation;
        
        while (timer < moveDuration)
        {
            float t = timer / moveDuration;
            transform.localPosition = Vector3.Lerp(startPosition, Vector3.zero, t);
            transform.localRotation = Quaternion.Slerp(startRotation, originalLocalRotation, t);

            timer += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator MoveBack()
    {
        float timer = 0;
        transform.SetParent(originalParent, true);
        Vector3 startPosition = transform.localPosition;
        Quaternion startRotation = transform.rotation;

        while (timer < moveDuration)
        {
            float t = timer / moveDuration;

            transform.localPosition = Vector3.Lerp(startPosition, originalLocalPosition, t);
            transform.localRotation = Quaternion.Slerp(startRotation, originalLocalRotation, t);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}