using System;
using UnityEngine;

public class WatcherAttack : MonoBehaviour
{
    [SerializeField] private Door rightDoor;
    [SerializeField] private float standDuration = 4f;

    [Header("JUMPSCARE SETUP")]
    [SerializeField] private Animator bonnieAnim;       // Kéo cục Bonnie (chứa Animator) vào đây
    [SerializeField] private Transform bonnieTransform; // Kéo cục Bonnie (chứa Transform) vào đây
    [SerializeField] private AudioSource jumpscareSound;// Tiếng thét

    private float timer;
    private bool isAttacking;

    public event Action Blocked;
    public event Action PlayerCaught;

    private void Update()
    {
        if (!isAttacking)
            return;

        if (!rightDoor.IsFullyClosed())
        {
            isAttacking = false;
            TriggerJumpscare(); // Chèn hàm gọi Jumpscare vào đây!
            PlayerCaught?.Invoke();
            return;
        }

        timer += Time.deltaTime;

        if (timer < standDuration)
            return;

        isAttacking = false;
        Blocked?.Invoke();
    }

    public void BeginAttack()
    {
        if (rightDoor == null)
            return;

        timer = 0f;
        isAttacking = true;
    }

    // Nút thần thánh để Test Jumpscare ngay lập tức
    [ContextMenu("💥 TEST JUMPSCARE NGAY VÀ LUÔN 💥")]
    public void TriggerJumpscare()
    {
        // 1. Tìm Camera của người chơi (Đảm bảo Camera của em có Tag là MainCamera nhé)
        Transform playerCam = Camera.main.transform;

        // 2. Dịch chuyển Bonnie ra thẳng trước mặt màn hình Player (cách 1.2 mét)
        bonnieTransform.position = playerCam.position + playerCam.forward * 1.2f - Vector3.up * 0.5f;

        // 3. Ép nó quay mặt nhìn trừng trừng vào người chơi
        Vector3 lookPos = playerCam.position;
        lookPos.y = bonnieTransform.position.y; // Giữ cho nó đứng thẳng không bị ngửa ngửa
        bonnieTransform.LookAt(lookPos);

        // 4. Bật Animation Jumpscare
        if (bonnieAnim != null) bonnieAnim.Play("Jumpscare");

        // 5. Bật tiếng thét
        if (jumpscareSound != null) jumpscareSound.Play();

        Debug.Log("JUMPSCARE!!!! THAY QUẦN ĐI SẾP!");
    }
}