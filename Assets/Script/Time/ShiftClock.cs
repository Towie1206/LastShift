using System;
using UnityEngine;

public class ShiftClock : MonoBehaviour
{
    public event Action<int> hourChanged;
    public event Action shiftCompleted;

    [SerializeField] private float secondsPerHour = 90f;
    [SerializeField] private int startHour = 23;
    [SerializeField] private int shiftDurationInHour = 7;

    public int currentHour { get; private set; }

    private float timer;
    private int elapsedHours;
    private bool isCompleted;

    private void Awake()
    {
        currentHour = startHour;
    }

    private void Start()
    {
        hourChanged?.Invoke(currentHour);
    }

    private void Update()
    {
        if (isCompleted)
            return;

        timer += Time.deltaTime;

        if (timer < secondsPerHour)
            return;

        timer -= secondsPerHour;
        AdvanceHour();
    }

    private void AdvanceHour()
    {
        elapsedHours++;
        currentHour = (startHour + elapsedHours) % 24; //1 ngày có 24 giờ chia lấy dư

        hourChanged?.Invoke(currentHour);

        if(elapsedHours >= shiftDurationInHour)
        {
            isCompleted = true;
            shiftCompleted?.Invoke();
        }
    }
}
