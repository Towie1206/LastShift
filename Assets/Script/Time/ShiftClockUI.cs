using TMPro;
using UnityEngine;

public class ShiftClockUI : MonoBehaviour
{
    [SerializeField] private ShiftClock shiftClock;
    [SerializeField] private TMP_Text text;

    private void OnEnable()
    {
        shiftClock.hourChanged += HandleHourChange;
    }

    private void OnDisable()
    {
        shiftClock.hourChanged -= HandleHourChange;
    }

    private void HandleHourChange(int hour)
    {
        int displayHour = hour % 12;

        if(displayHour == 0) 
            displayHour = 12;

        string suffix = hour < 12 ? "AM" : "PM";
        text.text = $"{displayHour}:00 {suffix}";
    }
}
