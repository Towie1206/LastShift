using System;
using UnityEngine;

public class LightControl : MonoBehaviour, IHoldInteractable, IPowerConsumer
{
    [SerializeField] private ToggleLight light;
    [SerializeField] private Material defautMat;
    [SerializeField] private Material holdMat;
    [SerializeField] private GameObject offLight;
    [SerializeField] private GameObject onLight;

    [SerializeField] private AudioSource lightBuzzAudio;

    public event Action<bool> OnLightStateChanged;

    private MeshRenderer meshRenderer;

    private bool isHolding;

    public bool IsConsumingPower => isHolding;

    public float PowerDrainRate => 1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        meshRenderer.material = defautMat;
    }

    public void OnPointerDown(Player player)
    {
        isHolding = true;
        light.LightControl();

        meshRenderer.material = holdMat;

        if (lightBuzzAudio != null) lightBuzzAudio.Play();

        OnLightStateChanged?.Invoke(true);
    }

    public void OnPointerUp(Player player)
    {
        if (!isHolding) return;
        isHolding = false;

        light.LightControl();

        meshRenderer.material = defautMat;

        if (lightBuzzAudio != null) lightBuzzAudio.Stop();

        OnLightStateChanged?.Invoke(false);
    }
}
