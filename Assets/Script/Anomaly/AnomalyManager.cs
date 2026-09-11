using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    [Header("Danh sách các anomaly")]
    [SerializeField] private AnomalyObject[] anomalies;
    [SerializeField] private WatcherBrain watcherBrain;

    [Header("Thời gian")]
    [SerializeField] private float minSpawnTime = 15f;
    [SerializeField] private float maxSpawnTime = 35f;

    private int point = 0;

    private void Start()
    {
        StartCoroutine(SpawnAnomalyRoutine());
    }

    private IEnumerator SpawnAnomalyRoutine()
    {

        yield return new WaitForSeconds(30f);
        float timePassed = 0f;
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
            timePassed += waitTime;
            List<AnomalyObject> inactiveAnomalies = new List<AnomalyObject>();

            foreach (var anomaly in anomalies)
            {
                if (!anomaly.IsActive)
                {
                    if (timePassed < 90f) // 12h - 1h
                    {
                        if (anomaly.AnomalyDifficulty == AnomalyDifficulty.Easy)
                            inactiveAnomalies.Add(anomaly);
                    }
                    else if (timePassed < 180f) // 1h - 2h
                    {
                        if (anomaly.AnomalyDifficulty <= AnomalyDifficulty.Normal)
                            inactiveAnomalies.Add(anomaly);
                    }
                    else if (timePassed < 270f) // 2h - 3h
                    {
                        if (anomaly.AnomalyDifficulty == AnomalyDifficulty.Hard)
                            inactiveAnomalies.Add(anomaly);
                    }
                    else // > 3h
                    {
                        if (anomaly.AnomalyDifficulty == AnomalyDifficulty.Bizarre)
                            inactiveAnomalies.Add(anomaly);
                    }
                }

                if (inactiveAnomalies.Count > 0)
                {
                    inactiveAnomalies[Random.Range(0, inactiveAnomalies.Count)].Activate();
                }

            }

        }
    }
    public bool ReceiveReport(AnomalyLocation location, AnomalyType type)
    {
        foreach (var anomaly in anomalies)
        {
            if (anomaly.IsActive && anomaly.AnomalyLocation == location && anomaly.AnomalyType == type)
            {
                anomaly.Deactivate();
                point++;
                return true;
            }
        }
        watcherBrain.ReportWrongResponse();
        return false;
    }

}
