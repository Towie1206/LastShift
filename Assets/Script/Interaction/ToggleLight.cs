using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    [SerializeField] private GameObject light;

    private bool isOn = false;

    private void Start()
    {
        light.SetActive(isOn);
    }
    public void LightControl()
    {
        isOn = !isOn;
        light.SetActive(isOn);
    }
}
