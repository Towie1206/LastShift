using TMPro;
using UnityEngine;

public class ShiftClockUI : MonoBehaviour
{
    [SerializeField] private ShiftClock shiftClock;
    [SerializeField] private TMP_Text text;

    private void OnEnable()
    {
        shiftClock.timeChanged += HandleHourChange;
    }

    private void OnDisable()
    {
        shiftClock.timeChanged -= HandleHourChange;
    }

    private void HandleHourChange(int hour,int minute)
    {
        int displayHour = hour % 12;
        int displayMinute = minute;

        if(displayHour == 0) 
            displayHour = 12;

        string suffix = hour < 12 ? "AM" : "PM";
        text.text = $"{displayHour}:{displayMinute:D2} {suffix}";
    }
}
