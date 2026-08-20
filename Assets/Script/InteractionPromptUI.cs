using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    [Header("Nên khớp với PlayerInteractor")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableLayer;

    [Header("UI cần hiện/ẩn")]
    [SerializeField] private GameObject promptUI;

    private void Update()
    {
        if (playerCamera == null || promptUI == null)
            return;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        bool isLookingAtInteractable =
            Physics.Raycast(ray, out RaycastHit hitInfo, interactDistance, interactableLayer) &&
            hitInfo.collider.GetComponentInParent<IInteractable>() != null;

        promptUI.SetActive(isLookingAtInteractable);
    }
}
