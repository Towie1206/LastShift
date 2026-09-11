using System;
using UnityEngine;

public class ShiftClock : MonoBehaviour
{
    public event Action<int, int> timeChanged;
    public event Action shiftCompleted;

    [SerializeField] private int startHour = 23;
    [SerializeField] private int startMinute = 30;
    [SerializeField] private int shiftDurationInHour = 7;

    public int currentHour { get; private set; }
    public int currentMinute { get; private set; }

    private float timer;
    private int elapsedGameMinutes;
    private bool isCompleted;

    private void Awake()
    {
        currentHour = startHour;
        currentMinute = startMinute;
    }

    private void Start()
    {
        timeChanged?.Invoke(currentHour, currentMinute);
    }

    private void Update()
    {
        if (isCompleted) return;
        timer += Time.deltaTime;
        // Cứ mỗi 1,5 giây ngoài đời thì nhảy 1 phút
        if (timer >= 1.5f)
        {
            timer -= 1.5f;
            AdvanceMinute();
        }
    }

    private void AdvanceMinute()
    {
        elapsedGameMinutes++;
        currentMinute++;

        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour = (currentHour + 1) % 24;
        }
        timeChanged?.Invoke(currentHour, currentMinute);

        if (elapsedGameMinutes >= shiftDurationInHour * 60)
        {
            isCompleted = true;
            shiftCompleted?.Invoke();
        }
    }
}
