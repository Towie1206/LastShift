using System;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDesktopView : MonoBehaviour
{
    [SerializeField] private GameObject computerUI;
    [SerializeField] private GameObject desktopPanel;
    [SerializeField] private GameObject laZoPanel;
    [SerializeField] private Button laZoAppButton;

    public event Action LaZoRequested;

    private void OnEnable()
    {
        laZoAppButton.onClick.AddListener(HandleLaZoClicked);
    }

    private void OnDisable()
    {
        laZoAppButton.onClick.RemoveListener(HandleLaZoClicked);
    }

    public void ShowDesktop()
    {
        desktopPanel.SetActive(true);
        laZoPanel.SetActive(false);
        computerUI.SetActive(true);
    }

    public void OpenLaZo()
    {
        desktopPanel.SetActive(false);
        laZoPanel.SetActive(true);
    }

    private void HandleLaZoClicked()
    {
        LaZoRequested?.Invoke();
    }
}