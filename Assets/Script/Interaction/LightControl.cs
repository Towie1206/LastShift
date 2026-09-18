using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class LightControl : MonoBehaviour, IHoldInteractable
{
    [SerializeField] private ToggleLight light;
    [SerializeField] private float maxHoldDuration = 3f;
    [SerializeField] private Material defautMat;
    [SerializeField] private Material holdMat;
    [SerializeField] private GameObject offLight;
    [SerializeField] private GameObject onLight;


    private MeshRenderer meshRenderer;

    private Coroutine autoTurnOffCo;
    private bool isHolding;


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

        if (autoTurnOffCo != null) StopCoroutine(autoTurnOffCo);
        autoTurnOffCo = StartCoroutine(AutoTurnOffRoutine());
    }

    public void OnPointerUp(Player player)
    {
        if (!isHolding) return;
        isHolding = false;

        if (autoTurnOffCo != null) StopCoroutine(autoTurnOffCo);

        light.LightControl();
        meshRenderer.material = defautMat;
    }
    private IEnumerator AutoTurnOffRoutine()
    {
        yield return new WaitForSeconds(maxHoldDuration);
        light.LightControl(); // Hết giờ tự ngắt
        isHolding = false;
    }
    private void LightButton()
    {
        if (offLight != null) offLight.SetActive(light.LightCheck());
        if (onLight != null) onLight.SetActive(!light.LightCheck());
    }
}
