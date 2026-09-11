using System;
using UnityEngine;

public class AnomalyObject : MonoBehaviour
{
    [Header("Định danh sự kiện")]
    [SerializeField] private AnomalyLocation anomalyLocation;
    [SerializeField] private AnomalyType anomalyType;
    [SerializeField] private AnomalyDifficulty anomalyDifficulty;

    [Header("Danh Sách Tráo Đổi")]
    [SerializeField] private GameObject[] normalObject;
    [SerializeField] private GameObject[] anomalyObject;
    public bool IsActive { get; private set; }

    private void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        foreach (var obj in normalObject)
        {
            obj.SetActive(false);
        }

        foreach (var obj in anomalyObject)
        {
            obj.SetActive(true);
        }
        IsActive = true;
    }
    public void Deactivate()
    {
        foreach (var obj in normalObject)
        {
            obj.SetActive(true);
        }

        foreach (var obj in anomalyObject)
        {
            obj.SetActive(false);
        }
        IsActive = false; 
    }

    public AnomalyType AnomalyType => anomalyType;
    public AnomalyLocation AnomalyLocation => anomalyLocation;
    public AnomalyDifficulty AnomalyDifficulty => anomalyDifficulty;
}
