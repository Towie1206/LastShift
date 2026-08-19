using UnityEngine;

public class CCTVView : MonoBehaviour
{
    [SerializeField] private GameObject cctvPanel;
    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        cctvPanel.SetActive(true);
    }

    public void Hide()
    {
        cctvPanel.SetActive(false);
    }

    public bool isVisible()
    {
        return cctvPanel != null && cctvPanel.activeInHierarchy;
    }    
}
