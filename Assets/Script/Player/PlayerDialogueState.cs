using UnityEngine;

public class PlayerDialogueState : PlayerState
{
    public PlayerDialogueState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

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
        if (player.input.Player.DialogueAdvance.WasPerformedThisFrame())
        {
            player.dialogueController.Advance();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
