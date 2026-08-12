using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;


    public void TryToInteract()
    {
        // tạo tia chiếu từ vị trí của camera người chơi theo hướng nhìn của camera
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        // out RaycastHit hitInfo: Lưu lại thông tin chi tiết của vật thể bị tia bắn trúng.
        if (Physics.Raycast(ray,out RaycastHit hitInfo,interactDistance,interactableLayer)) 
        {
            IInteractable interactable =hitInfo.collider.GetComponentInParent<IInteractable>();

            interactable?.Interact();
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
