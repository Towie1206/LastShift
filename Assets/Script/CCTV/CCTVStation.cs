using UnityEngine;

public class CCTVStation : MonoBehaviour, IInteractable
{

    [SerializeField] private Player player;
    public void Interact()
    {
        if(player == null) return;
        player.stateMachine.ChangeState(player.cctvState);
    }
}
