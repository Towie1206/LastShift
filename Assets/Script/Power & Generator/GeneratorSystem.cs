using System;
using UnityEngine;

public class GeneratorSystem : MonoBehaviour
{
    [Header("Electricity")]
    [SerializeField] private float maxPower = 100f; 
    [SerializeField] private float drainRate = 3f;
    [SerializeField] private float rechargeRate = 10f;

    public event Action<float> OnPowerChanged;

    private float currentPower;
    private bool isGeneratorActive = false;
    private bool isRecharging = false;


    public void StartGenerator()
    {
        currentPower = maxPower;
        OnPowerChanged?.Invoke(currentPower / maxPower);
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

        OnPowerChanged?.Invoke(currentPower / maxPower);

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
