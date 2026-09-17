using UnityEngine;

public class PlayerComputerState : PlayerState
{
    private MaintenanceStation activeStation;

    public PlayerComputerState(Player player, StateMachine stateMachine) : base(player, stateMachine) { }

    public void SetStation(MaintenanceStation station)
    {
        activeStation = station;
    }

    public override void Enter()
    {
        base.Enter();
        player.movement.Stop();
        player.look.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (activeStation != null)
        {
            // 1. Bảo cái máy mở lên
            activeStation.Open();

            // 2. Tự lắng nghe: Khi nào cái máy đóng thì NÃO TỰ THOÁT!
            activeStation.OnStationClosed += HandleStationClosed;
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.look.enabled = true;

        if (activeStation != null)
        {
            activeStation.OnStationClosed -= HandleStationClosed;
            activeStation = null;
        }
    }

    // Khi nhận được tín hiệu máy đã tắt -> Tự đưa bản thân về lại ghế văn phòng!
    private void HandleStationClosed()
    {
        stateMachine.ChangeState(player.officeState);
    }
}