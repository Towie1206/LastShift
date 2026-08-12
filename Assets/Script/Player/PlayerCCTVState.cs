using UnityEngine;

public class PlayerCCTVState : PlayerState
{
    public PlayerCCTVState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();
        player.cctvView.Show();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public override void Update()
    {
        base.Update();

        if(input.Player.Exit.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.freeState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        player.cctvView.Hide();
    }
}
