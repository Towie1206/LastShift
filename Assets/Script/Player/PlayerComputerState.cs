using UnityEngine;

public class PlayerComputerState : PlayerState
{
    public PlayerComputerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();
        player.look.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void Exit()
    {
        base.Exit();
        player.look.enabled = true;
    }
}
