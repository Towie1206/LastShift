using UnityEngine;
using UnityEngine.UI;

public class GeneratorUI : MonoBehaviour
{
    [SerializeField] private Image powerCircle;

    [SerializeField] private GeneratorSystem generatorSystem;

    private void OnEnable()
    {
        generatorSystem.OnPowerChanged += HandleFillAmount;
    }
    private void OnDisable()
    {
        generatorSystem.OnPowerChanged -= HandleFillAmount;
    }
    private void HandleFillAmount(float fillRatio)
    {
        powerCircle.fillAmount = fillRatio;
    }

}
