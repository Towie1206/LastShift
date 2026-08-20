using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Letter : MonoBehaviour, IInteractable
{
    [Header("Player reference")]
    [SerializeField] private Player player;

    [Header("Letter visuals")]
    [SerializeField] private GameObject letterUI;
    [SerializeField] private Renderer letterMesh;

    [Header("Options")]
    [SerializeField] private bool freezePlayerWhileReading = true;
    [SerializeField] private bool toggleCursorWhileReading = true;

    private bool isOpen;

    private void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>(); 
            if (player == null)
                Debug.LogWarning($"[Letter] '{name}' chưa gán Player và cũng không tìm thấy Player nào trong scene.");
        }
    }

    public void Interact()
    {
        isOpen = !isOpen;

        if (letterUI != null)
            letterUI.SetActive(isOpen);

        if (letterMesh != null)
            letterMesh.enabled = !isOpen;

        if (freezePlayerWhileReading && player != null)
            SetPlayerFrozen(isOpen);

        if (toggleCursorWhileReading)
        {
            Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isOpen;
        }
    }

    private void SetPlayerFrozen(bool frozen)
    {
        if (frozen)
        {
            player.movement.Stop();
            player.input.Player.Move.Disable();
            player.input.Player.Look.Disable();
        }
        else
        {
            player.input.Player.Move.Enable();
            player.input.Player.Look.Enable();
        }
    }
}
