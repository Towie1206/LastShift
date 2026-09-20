using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerOfficeState : PlayerState
{
    public PlayerOfficeState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        officeViewManager = player.GetComponent<OfficeViewManager>();
    }

    private OfficeViewManager officeViewManager;

    private IHoldInteractable currentHolding;
    private bool wasInLeftEdge = false;
    private bool wasInRightEdge = false;
    private float edgePercent = .08f; // 8% mép màn hình mỗi bên (khoảng 150px)
    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();

        player.look.ResetLook(0f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      
    }

    override public void Update()
    {
        base.Update();

        HandleEdgeHover();

        // Khi bấm chuột trái

        if (Mouse.current != null)
        {
            // 1. KHI VỪA ẤN CHUỘT XUỐNG:
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
                player.interactor.TryStartInteract(Mouse.current.position.ReadValue());
            }
            // 2. KHI VỪA NHẢ CHUỘT RA:
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                player.interactor.StopInteract();
            }
        }
    }

    private void HandleEdgeHover()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        float leafBoundary = Screen.width * edgePercent;
        float rightBoundary = Screen.width * (1f - edgePercent);

        bool inLeft = mousePosition.x <= leafBoundary;
        bool inRight = mousePosition.x >= rightBoundary;

        // Chỉ kích hoạt xoay khi chuột VỪA CHẠM vào mép
        if (inLeft && !wasInLeftEdge) officeViewManager.TurnLeft();

        else if (inRight && !wasInRightEdge) officeViewManager.TurnRight();

        wasInLeftEdge = inLeft;
        wasInRightEdge = inRight;
    }
}
