using System;
using System.Collections;
using UnityEngine;
using static OfficeViewManager;

public class PowerOutageController : MonoBehaviour
{
    [SerializeField] private GeneratorSystem generatorSystem;
    [SerializeField] private GameObject[] light;
    [SerializeField] private GameObject lightPowerOutage;
    [SerializeField] private GameObject[] freddyLight;
    [SerializeField] private Door[] door;
    [SerializeField] private Player player;
    [SerializeField] private OfficeViewManager officeViewManager;
    [SerializeField] private AudioSource freddySound;

    [Header("Watcher")]
    [SerializeField] private WatcherLocation attackLocation;
    [SerializeField] private WatcherMovement movement;

    public event Action OnBlackoutKill;

    private void OnEnable()
    {
        generatorSystem.OnPowerOutage += HandlePowerOutage;
    }
    private void OnDisable()
    {
        generatorSystem.OnPowerOutage -= HandlePowerOutage;
    }

    private void HandlePowerOutage()
    {
        lightPowerOutage.SetActive(true);
        for (int i = 0; i < light.Length; i++)
            light[i].SetActive(false);
        for (int i = 0; i < door.Length; i++)
            door[i].ForceOpen();

        player.ForceOfficeView();
        officeViewManager.SetView(OfficeView.Right, instant: true);
        StartCoroutine(FreddyJump());
    }

    private IEnumerator FreddyJump()
    {
        float t = 0;
        movement.MoveTo(attackLocation);
        freddySound.Play();
        while (t < 7.5)
        {
            t += .4f;
            for(int i =0;i< freddyLight.Length;i++)
                freddyLight[i].SetActive(true);

            yield return new WaitForSeconds(.2f); // vòng lập sẽ chạy mỗi .2s 

            for (int i = 0; i < freddyLight.Length; i++)
                freddyLight[i].SetActive(false);

            yield return new WaitForSeconds(.2f);
        }
        freddySound.Stop();
        for (int i = 0; i < freddyLight.Length; i++)
            freddyLight[i].SetActive(false);
        yield return new WaitForSeconds(1.75f);

        OnBlackoutKill?.Invoke();
        yield return new WaitForSeconds(1.75f);
        lightPowerOutage.SetActive(false);
    }
}
