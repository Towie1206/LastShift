using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f; //fps
    [SerializeField] private float interactDistanceClick = 5f; //tpp
    [SerializeField] private LayerMask interactableLayer;

    private Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // 👈 Biến nhớ: Ngón tay đang đè lên cái gì?
    private IHoldInteractable currentHolding;
    // Khi ngón tay ẤN XUỐNG:
    public void TryStartInteract(Vector2 mouseScreenPos)
    {
        Ray ray = playerCamera.ScreenPointToRay(mouseScreenPos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactDistanceClick, interactableLayer))
        {
            // Trường hợp 1: Nếu là đồ vật ấn giữ (Nút Đèn)
            IHoldInteractable holdable = hitInfo.collider.GetComponentInParent<IHoldInteractable>();
            if (holdable != null)
            {
                currentHolding = holdable; // Ghi nhớ lại
                currentHolding.OnPointerDown(player); // Bảo nút đèn: "Bật lên!"
                return;
            }
            // Trường hợp 2: Nếu là đồ vật bấm 1 phát ăn ngay (Cửa, Bức thư, CCTV)
            IInteractable interactable = hitInfo.collider.GetComponentInParent<IInteractable>();
            interactable?.Interact(player); // Vẫn chạy như bình thường!
        }
    }

    public void StopInteract()
    {
        if (currentHolding != null)
        {
            currentHolding.OnPointerUp(player); // Bảo nút đèn: "Tắt đi!"
            currentHolding = null; // Quên đi, hết đè rồi
        }
    }
    public void TryToInteract()
    {
        // tạo tia chiếu từ vị trí của camera người chơi theo hướng nhìn của camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        // out RaycastHit hitInfo: Lưu lại thông tin chi tiết của vật thể bị tia bắn trúng.
        if (Physics.Raycast(ray,out RaycastHit hitInfo,interactDistance,interactableLayer)) 
        {
            IInteractable interactable =hitInfo.collider.GetComponentInParent<IInteractable>();

            interactable?.Interact(player);
        }
    }    
  
    private void OnDrawGizmos()
    {
        if(playerCamera == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactDistance);
    }
}
