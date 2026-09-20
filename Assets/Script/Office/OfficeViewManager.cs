using UnityEngine;


public class OfficeViewManager : MonoBehaviour
{
    [Header("Office View")]
    [SerializeField] private Transform frontView;
    [SerializeField] private Transform backView;
    [SerializeField] private Transform leftView;
    [SerializeField] private Transform rightView;

    [Header("Speed")]
    [SerializeField] private float rotationSpeed = 15f;
    public enum OfficeView { Front, Right, Back, Left }
    private OfficeView currentView = OfficeView.Front;
    public OfficeView CurrentView() => currentView;

    private Transform targetView;
    private bool isRotating = false;


    private void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetView.rotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetView.rotation) < 0.5f)
            {
                transform.rotation = targetView.rotation;
                isRotating = false;
            }
        }
    }

    public void TurnLeft()
    {
        if (isRotating) return;
        switch (currentView)
        {
            case OfficeView.Front:
                targetView = leftView;
                currentView = OfficeView.Left;
                break;
            case OfficeView.Left:
                targetView = backView;
                currentView = OfficeView.Back;
                break;
            case OfficeView.Back:
                targetView = rightView;
                currentView = OfficeView.Right;
                break;
            case OfficeView.Right:
                targetView = frontView;
                currentView = OfficeView.Front;
                break;
        }
        isRotating = true;
    }

    public void TurnRight()
    {
        if (isRotating) return;
        switch (currentView)
        {
            case OfficeView.Front:
                targetView = rightView;
                currentView = OfficeView.Right;
                break;
            case OfficeView.Right:
                targetView = backView;
                currentView = OfficeView.Back;
                break;
            case OfficeView.Back:
                targetView = leftView;
                currentView = OfficeView.Left;
                break;
            case OfficeView.Left:
                targetView = frontView;
                currentView = OfficeView.Front;
                break;

        }
        isRotating = true;
    }

    public void ResetToFront()
    {
        currentView = OfficeView.Front;
        targetView = frontView;
        if (frontView != null)
        {
            transform.rotation = frontView.rotation;
        }
        isRotating = false;
    }

    public void SetView(OfficeView view, bool instant = false)
    {
        currentView = view;
        switch (view)
        {
            case OfficeView.Front:
                targetView = frontView;
                break;
            case OfficeView.Back:
                targetView = backView;
                break;
            case OfficeView.Left:
                targetView = leftView;
                break;
            case OfficeView.Right:
                targetView = rightView;
                break;
        }

        if (instant && targetView != null)
        {
            transform.rotation = targetView.rotation;
            isRotating = false;
        }
        else
            isRotating = true;
    }
}
