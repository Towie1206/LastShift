public class PlayerLetterState : PlayerState
{
    public PlayerLetterState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    private LetterStation currentLetter;

    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();
        currentLetter?.PickUp(player.holdPoint);

    }

    public override void Update()
    {
        base.Update();
        if (input.Player.Exit.WasPerformedThisFrame())
        {
            player.CloseLetter();
        }
    }
    public override void Exit()
    {
        base.Exit();
        currentLetter?.PutBack();
        currentLetter = null;
    }

    public void SetLetter(LetterStation letter)
    {
        currentLetter = letter;
    }
}
