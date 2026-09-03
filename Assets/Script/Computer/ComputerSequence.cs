using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ComputerSequence : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private float cameraBlendDuration = 1.5f;
    [SerializeField] private ManagerChatController chatController;
    [SerializeField] private int monitorPriority = 20;
    [SerializeField] private ComputerDesktopView desktopView;

    private bool isRunning;
    private Coroutine enterRoutine;

    private void OnEnable()
    {
        desktopView.LaZoRequested += HandleLaZoRequested;
    }

    private void OnDisable()
    {
        desktopView.LaZoRequested -= HandleLaZoRequested;
    }

    public void Play()
    {
        if (isRunning)
        {
            return;
        }

        isRunning = true;

        player.EnterComputer();
        cinemachineCamera.Priority = monitorPriority;

        enterRoutine =
            StartCoroutine(OpenDesktopAfterBlend());
    }
    private IEnumerator OpenDesktopAfterBlend()
    {
        yield return new WaitForSeconds(cameraBlendDuration);

        enterRoutine = null;
        desktopView.ShowDesktop();
    }

    private void HandleLaZoRequested()
    {
        desktopView.OpenLaZo();
        chatController.Play();
    }
}
