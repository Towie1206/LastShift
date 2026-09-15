using UnityEngine;

public class PlayerCCTVState : PlayerState
{
    public PlayerCCTVState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    private CCTVStation currentStation;

    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public override void Update()
    {
        base.Update();

        if(input.Player.Exit.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.officeState);
        }
    }
    public void SetStation(CCTVStation station)
    {
        currentStation = station;
    }

    public override void Exit()
    {
        base.Exit();
        currentStation?.CloseCCTV();
        currentStation = null;
    }
}
