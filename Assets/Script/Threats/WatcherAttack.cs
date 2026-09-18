using System;
using UnityEngine;
using static OfficeViewManager;

public class WatcherAttack : MonoBehaviour
{
    [SerializeField] private Door rightDoor;
    [SerializeField] private float standDuration = 5f;

    [SerializeField] private Animator anim;
    [SerializeField] private Transform freedyTransform;
    [SerializeField] private Transform deskJumpscarePoint;
    [SerializeField] private Transform maintanceJumpscarePoint;
    [SerializeField] private Transform leftDoorJumpscarePoint;
    [SerializeField] private Transform rightDoorJumpscarePoint;
    [SerializeField] private AudioSource jumpscareSound;// Tiếng thét

    private float timer;
    private bool isAttacking;

    public event Action Blocked;
    public event Action PlayerCaught;

    private void Update()
    {
        if (!isAttacking)
            return;

        timer += Time.deltaTime;
        if (timer < standDuration)
            return;

        isAttacking = false;
        if (rightDoor.IsFullyClosed())
        {
            // Sống sót: Quái bị chặn, bỏ đi!
            Blocked?.Invoke();
        }
        else
        {
            // Toang: Cửa chưa đóng kịp -> Jumpscare!
            PlayerCaught?.Invoke();
        }

    }

    public void BeginAttack()
    {
        if (rightDoor == null)
            return;

        timer = 0f;
        isAttacking = true;
    }

    public void PerformJumpscare(OfficeViewManager.OfficeView view)
    {

        Transform targetPoint = deskJumpscarePoint;

        switch (view)
        {
            case OfficeView.Front:
                targetPoint = deskJumpscarePoint;
                break;
            case OfficeView.Back:
                targetPoint = maintanceJumpscarePoint;
                break;
            case OfficeView.Left:
                targetPoint = leftDoorJumpscarePoint;
                break;
            case OfficeView.Right:
                targetPoint = rightDoorJumpscarePoint;
                break;
        }

        freedyTransform.position = targetPoint.position;
        freedyTransform.rotation = targetPoint.rotation;

        if (view == OfficeView.Left || view == OfficeView.Right)
        {
            if (anim != null) anim.Play("Freddy_Leap");
        }
        else // Nếu ở Bàn hoặc Bảo trì thì chơi anim cũ:
        {
            if (anim != null) anim.Play("Freddy_Jumpscare");
        }
        if (jumpscareSound != null) jumpscareSound.Play();

    }
    [ContextMenu("💥 TEST JUMPSCARE BAN DƯỚI 💥")]
    public void TestDesk() => PerformJumpscare(OfficeViewManager.OfficeView.Front);

    [ContextMenu("💥 TEST JUMPSCARE CỬA TRÁI 💥")]
    public void TestLeft() => PerformJumpscare(OfficeViewManager.OfficeView.Left);
}
