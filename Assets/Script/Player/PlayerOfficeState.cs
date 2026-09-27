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

    // Biến hỗ trợ vuốt màn hình trên Mobile (Android Touch Swipe)
    private Vector2 touchStartPos;
    private bool isTouching = false;
    private bool hasSwiped = false;
    private float swipeThresholdPercent = 0.08f; // Vuốt tối thiểu 8% chiều rộng màn hình để kích hoạt
    private bool invertSwipe = false; // false: Vuốt sang trái -> Quay trái; Vuốt sang phải -> Quay phải

    // Giả lập vuốt trên PC Editor bằng chuột phải để test nhanh
    private Vector2 mouseDragStartPos;
    private bool isMouseDragging = false;
    private bool hasMouseSwiped = false;

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

        // 1. Xử lý cảm ứng vuốt màn hình trên Android
        HandleTouchInput();

        // 2. Xử lý chuột trên PC (Rê mép màn hình, chuột trái tương tác, chuột phải giả lập vuốt)
        HandleMouseInput();
    }

    private void HandleTouchInput()
    {
        if (Touchscreen.current == null) return;

        var touch = Touchscreen.current.primaryTouch;

        // 1. KHI NGÓN TAY CHẠM XUỐNG:
        if (touch.press.wasPressedThisFrame)
        {
            Vector2 screenPos = touch.position.ReadValue();

            // Nếu bấm trúng giao diện Canvas (UI) thì không kích hoạt vuốt
            if (EventSystem.current != null && (EventSystem.current.IsPointerOverGameObject(touch.touchId.ReadValue()) || EventSystem.current.IsPointerOverGameObject()))
                return;

            touchStartPos = screenPos;
            isTouching = true;
            hasSwiped = false;

            // Bắt đầu tương tác tại điểm chạm (bấm cửa, giữ nút đèn pin...)
            player.interactor.TryStartInteract(screenPos);
        }

        // 2. KHI ĐANG GIỮ VÀ KÉO VUỐT NGÓN TAY:
        if (isTouching && touch.press.isPressed)
        {
            Vector2 currentPos = touch.position.ReadValue();
            Vector2 delta = currentPos - touchStartPos;
            float minSwipeDist = Screen.width * swipeThresholdPercent;

            // Nếu kéo ngang đủ khoảng cách và ưu tiên kéo ngang hơn kéo dọc (|delta.x| > |delta.y|)
            if (!hasSwiped && Mathf.Abs(delta.x) >= minSwipeDist && Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                hasSwiped = true;

                // Đã nhận diện hành động VUỐT xoay góc nhìn -> Ngắt giữ nút đèn pin
                player.interactor.StopInteract();

                if (delta.x > 0)
                {
                    // Vuốt sang PHẢI
                    if (!invertSwipe) officeViewManager.TurnRight();
                    else officeViewManager.TurnLeft();
                }
                else
                {
                    // Vuốt sang TRÁI
                    if (!invertSwipe) officeViewManager.TurnLeft();
                    else officeViewManager.TurnRight();
                }
            }
        }

        // 3. KHI NHẤC NGÓN TAY RA:
        if (touch.press.wasReleasedThisFrame)
        {
            if (isTouching)
            {
                isTouching = false;
                player.interactor.StopInteract();
            }
        }
    }

    private void HandleMouseInput()
    {
        if (Mouse.current == null) return;

        // Rê chuột chạm mép màn hình để quay (chuẩn PC)
        HandleEdgeHover();

        // Giả lập vuốt bằng giữ chuột phải kéo sang trái/phải để test nhanh trong Unity Editor
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            mouseDragStartPos = Mouse.current.position.ReadValue();
            isMouseDragging = true;
            hasMouseSwiped = false;
        }

        if (isMouseDragging && Mouse.current.rightButton.isPressed)
        {
            Vector2 currentPos = Mouse.current.position.ReadValue();
            float deltaX = currentPos.x - mouseDragStartPos.x;
            float minSwipeDist = Screen.width * swipeThresholdPercent;

            if (!hasMouseSwiped && Mathf.Abs(deltaX) >= minSwipeDist)
            {
                hasMouseSwiped = true;
                if (deltaX > 0)
                {
                    if (!invertSwipe) officeViewManager.TurnRight();
                    else officeViewManager.TurnLeft();
                }
                else
                {
                    if (!invertSwipe) officeViewManager.TurnLeft();
                    else officeViewManager.TurnRight();
                }
            }
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            isMouseDragging = false;
        }

        // Chuột trái: Bấm / giữ tương tác đồ vật
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
            player.interactor.TryStartInteract(Mouse.current.position.ReadValue());
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            player.interactor.StopInteract();
        }
    }

    private void HandleEdgeHover()
    {
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
