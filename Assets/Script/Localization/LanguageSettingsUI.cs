using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsUI : MonoBehaviour
{
    [Header("UI References")]
    public Image imgBtnVietnamese;
    public Image imgBtnEnglish;

    public Color activeColor = Color.white;
    public Color inactiveColor = new Color(0.5f, 0.5f, 0.5f, 1f);


    private void Start()
    {
        UpdateVisuals();
    }
    public void SetVietnamese()
    {
        LanguageManager.IsEnglish = false;
        UpdateVisuals();
    }

    public void SetEnglish()
    {
        LanguageManager.IsEnglish = true;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (LanguageManager.IsEnglish)
        {
            imgBtnEnglish.color = activeColor;
            imgBtnVietnamese.color = inactiveColor;
        }
        else
        {
            imgBtnEnglish.color = inactiveColor;
            imgBtnVietnamese.color = activeColor;
        }
    }
}
