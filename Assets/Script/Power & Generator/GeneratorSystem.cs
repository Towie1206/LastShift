using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSystem : MonoBehaviour
{
    [Header("Electricity")]
    [SerializeField] private float maxPower = 100f; 
    [SerializeField] private float drainRate = 2f;
    [SerializeField] private float rechargeRate = 10f;
    private int lastUsageLevel = -1;
    private IPowerConsumer[] consumers;

    public void SetupConsumers(IPowerConsumer[] consumers)
    {
        this.consumers = consumers;
    }

    public event Action<float> OnPowerChanged;

    public event Action OnPowerOutage;

    public event Action<int> OnUsageLevelChanged;

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
        {
            int activeCount = 0;
            float totalDrain = drainRate;
            if (consumers != null)
            {
                for (int i = 0; i < consumers.Length; i++)
                {
                    if (consumers[i] != null && consumers[i].IsConsumingPower)
                    {
                        activeCount++;
                        totalDrain += consumers[i].PowerDrainRate;
                    }    
                }
            }
            int currentUsageLevel = 1 + activeCount;
            if (currentUsageLevel != lastUsageLevel)
            {
                lastUsageLevel = currentUsageLevel;
                OnUsageLevelChanged?.Invoke(currentUsageLevel);
            }
            currentPower -= totalDrain * Time.deltaTime;
        }
        currentPower = Mathf.Clamp(currentPower, 0, maxPower);
        OnPowerChanged?.Invoke(currentPower / maxPower);
        if (currentPower <= 0) TriggerPowerOutage();
    }

    public void SetReCharging(bool state)
    {
        isRecharging = state;
    }    
    private void TriggerPowerOutage()
    {
        isGeneratorActive = false;
        Debug.Log("Power outage! Generator has run out of power.");
        OnPowerOutage?.Invoke();
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
