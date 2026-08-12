using UnityEngine;

public class BrokenDoorButton : MonoBehaviour , IInteractable
{

    [SerializeField] private InteractionMessageUI interactionMessageUI;
    [SerializeField] private string interactionMessage = "DOOR CONTROL OFFLINE";


    public void Interact()
    {
        interactionMessageUI.Show(interactionMessage);
    }
}
