using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class PhoneStation : MonoBehaviour, IInteractable
{
    [SerializeField] private Player player;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private DialogueData data;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private AudioSource ringing;

    private Collider collider;
    private float moveDuration = .75f;
    private Coroutine moveCo;
    private Transform parentTranform;
    private Vector3 originalTranformPosition;
    private Quaternion originalTranformRotation;


    private bool isRinging, isInUse;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    public void Interact()
    {
        if (!isRinging)
            return;

        isRinging = false;
        isInUse = true;
        ringing.Stop();
        dialogueController.Completed += HandleEnd;
        PickUp(holdPoint);
        player.EnterDialogue();

    }

    public void StartRinging()
    {
        ringing.Play();
        isRinging = true;
    }

    private void PickUp(Transform holdPoint)
    {
        if (holdPoint == null)
            return;

        parentTranform = transform.parent;
        originalTranformPosition = transform.localPosition;
        originalTranformRotation = transform.localRotation;

        if(moveCo != null)
            StopCoroutine(moveCo);
        moveCo = StartCoroutine(MoveToHoldPoint(holdPoint));

        collider.enabled = false;
        isInUse = true;



    }
    public void PutBack()
    {
        if (!isInUse)
            return;

        if (moveCo != null)
            StopCoroutine(moveCo);
        moveCo = StartCoroutine(MoveBack());

        collider.enabled = true;

        isInUse = false;
    }


    private IEnumerator MoveToHoldPoint(Transform holdPoint)
    {
        float timer = 0;
        transform.SetParent(holdPoint, true);
        Vector3 startPosition = transform.localPosition;
        Quaternion startRotation = transform.localRotation;

        while (timer < moveDuration) 
        {
            float t = timer/moveDuration;
            transform.localPosition = Vector3.Lerp(startPosition,Vector3.zero, t);
            transform.localRotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0,0,45), t);

            timer += Time.deltaTime;
            yield return null;
        }

        dialogueController.Play(data);
    }    
    private IEnumerator MoveBack()
    {
        float timer = 0;
        transform.SetParent(parentTranform, true);
        Vector3 startPosition = transform.localPosition;
        Quaternion startRotation = transform.localRotation;

        while (timer < moveDuration) 
        {
            float t = timer/moveDuration;
            transform.localPosition = Vector3.Lerp(startPosition,originalTranformPosition, t);
            transform.localRotation = Quaternion.Slerp(startRotation, originalTranformRotation, t);

            timer += Time.deltaTime;
            yield return null;
        }
    }    

    private void HandleEnd()
    {
        if (!isInUse) return;
        dialogueController.Completed -= HandleEnd;
        PutBack();
        collider.enabled = true;
        isInUse = false;
        moveCo = null;
        player.ExitDialogue();
    }
}
