using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput input { get; private set; }
    public StateMachine stateMachine { get; private set; }
    public PlayerFreeState freeState { get; private set; }
    public PlayerCCTVState cctvState { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerLook look { get; private set; }
    public PlayerInteractor interactor { get; private set; }
    public PlayerLetterState letterState { get; private set; }
    public PlayerDialogueState dialogueState { get; private set; }
    public PlayerComputerState computerState { get; private set; }
    public PlayerOfficeState officeState { get; private set; }

    [SerializeField] private Transform holdPointReference;
    [SerializeField] private DialogueController dialogueControllerReference;
    public Transform holdPoint => holdPointReference;
    public DialogueController dialogueController => dialogueControllerReference;

    public Vector2 moveInput { get; private set; }
    public Vector2 mousePosition { get; private set; }
    private void Awake()
    {
        input = new PlayerInput();
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        interactor = GetComponent<PlayerInteractor>();

        stateMachine = new StateMachine();
        freeState = new PlayerFreeState(this, stateMachine);
        cctvState = new PlayerCCTVState(this, stateMachine);
        letterState = new PlayerLetterState(this, stateMachine);
        dialogueState = new PlayerDialogueState(this, stateMachine);
        computerState = new PlayerComputerState(this, stateMachine);
        officeState = new PlayerOfficeState(this, stateMachine);

        stateMachine.Initialize(freeState);
    }
    private void OnEnable()
    {

        input.Enable();

        input.Player.Look.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += ctx => mousePosition = Vector2.zero;
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); //ctx = context
        input.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        input.Player.Exit.performed += OnExitPressed;

        if (dialogueController != null)
        {
            dialogueController.Started += EnterDialogue;
            dialogueController.Completed += ExitDialogue;
        }
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Exit.performed -= OnExitPressed;

        if (dialogueController != null)
        {
            dialogueController.Started -= EnterDialogue;
            dialogueController.Completed -= ExitDialogue;
        }
    }

    private void OnExitPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (PauseMenuController.Instance != null)
        {
            PauseMenuController.Instance.TogglePause();
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    public void EnterCCTV(CCTVStation station)
    {
        cctvState.SetStation(station);
        stateMachine.ChangeState(cctvState);
    }
    public void ExitCCTV()
    {
        stateMachine.ChangeState(officeState);
    }    

    public void OpenLetter (LetterStation letter)
    {
        letterState.SetLetter(letter);
        stateMachine.ChangeState(letterState);
    }    

    public void CloseLetter ()
    {
        stateMachine.ChangeState(officeState);
    } 

    public void EnterDialogue()
    {
        stateMachine.ChangeState(dialogueState);
    }

    public void ExitDialogue()
    {
        stateMachine.ChangeState(freeState);
    }
    public void EnterComputer()
    {
        stateMachine.ChangeState(computerState);
    }

    public void ExitComputer()
    {
        stateMachine.ChangeState(officeState);
    }

    public void EnterOffice()
    {
        stateMachine.ChangeState(officeState);
    }

    public void UseMaintenanceComputer(MaintenanceStation station)
    {
        computerState.SetStation(station);
        stateMachine.ChangeState(computerState); // Não tự chuyển state!
    }

    public void ForceOfficeView()
    {
        stateMachine.ChangeState(officeState); // Tự về lại ghế văn phòng
        input.Disable();                      // Khóa phím và chuột hoàn toàn
    }
}
