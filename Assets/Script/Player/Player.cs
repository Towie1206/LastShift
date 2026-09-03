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

    [SerializeField] private CCTVView cctvViewReference;
    [SerializeField] private Transform holdPointReference;
    [SerializeField] private DialogueController dialogueControllerReference;
    public Transform holdPoint => holdPointReference;
    public CCTVView cctvView => cctvViewReference;
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

        stateMachine.Initialize(freeState);
    }
    private void OnEnable()
    {

        input.Enable();

        input.Player.Look.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        input.Player.Look.canceled += ctx => mousePosition = Vector2.zero;
        //input just begun
        //input.Player.Movement.started += ctx => stateMachine.ChangeState(moveState);
        //input is performed
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); //ctx = context
        //input stoped,when you release the key
        input.Player.Move.canceled += ctx => moveInput = Vector2.zero;


    }

    private void OnDisable()
    {

        input.Disable();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    public void ExitCCTV()
    {
        stateMachine.ChangeState(freeState);
    }    

    public void OpenLetter (LetterStation letter)
    {
        letterState.SetLetter(letter);
        stateMachine.ChangeState(letterState);
    }    

    public void CloseLetter ()
    {
        stateMachine.ChangeState(freeState);
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
        stateMachine.ChangeState(freeState);
    }


}
