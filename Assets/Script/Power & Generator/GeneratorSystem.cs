using UnityEngine;
using UnityEngine.UI;

public class GeneratorSystem : MonoBehaviour
{
    [Header("Electricity")]
    [SerializeField] private float maxPower = 100f; 
    [SerializeField] private float drainRate = 3f;
    [SerializeField] private float rechargeRate = 10f;

    [Header("UI")]
    [SerializeField] private Image powerCircle;

    private float currentPower;
    private bool isGeneratorActive = false;
    private bool isRecharging = false;

    public void StartGenerator()
    {
        currentPower = maxPower;
        powerCircle.fillAmount = currentPower / maxPower;
        isGeneratorActive = true;
    }

    void Update()
    {
        if(!isGeneratorActive) return;

        if(isRecharging)
            currentPower += rechargeRate * Time.deltaTime;   
        else
            currentPower -= drainRate * Time.deltaTime;

        currentPower = Mathf.Clamp(currentPower, 0, maxPower);

        powerCircle.fillAmount = currentPower / maxPower;

        if (currentPower <= 0)
        {
            TriggerPowerOutage();
        }
    }

    public void SetReCharging(bool state)
    {
        isRecharging = state;
    }    
    private void TriggerPowerOutage()
    {
        isGeneratorActive = false;
        Debug.Log("Power outage! Generator has run out of power.");
        // watcherBrain.JumpScare();
    }

    public void StartGeneratorAfterDelay(float delayTime)
    {
        StartCoroutine(WaitAndStart(delayTime));
    }

    private System.Collections.IEnumerator WaitAndStart(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 

        StartGenerator();
    }
}
