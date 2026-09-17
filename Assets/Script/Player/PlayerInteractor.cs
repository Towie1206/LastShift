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

    public void TryToInteractFromCursor(Vector2 mouseScreenPos)
    {
        Ray ray = playerCamera.ScreenPointToRay(mouseScreenPos);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactDistanceClick, interactableLayer))
        {
            IInteractable interactable = hitInfo.collider.GetComponentInParent<IInteractable>();
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
