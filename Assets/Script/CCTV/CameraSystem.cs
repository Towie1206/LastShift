using System.Collections;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private RenderTexture outputTexture;
    [SerializeField] private int startingCameraIndex;
    [SerializeField] private GameObject offlineCamUI;
    [Header("Audio")]
    [SerializeField] private AudioSource switchCamAudio;

    [Header("Hiệu ứng chuyển Cam")]
    [SerializeField] private GameObject transitionStaticUI;
    public int currentCamIndex { get; private set; }

    private void Awake()
    {
        if (cameras == null || cameras.Length == 0)
            return;

        if (outputTexture == null)
            return;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].targetTexture = outputTexture;
            cameras[i].gameObject.SetActive(false);
        }
        currentCamIndex = startingCameraIndex;

        ShowCamera(currentCamIndex);
    }

    public void ShowCamera(int camIndex)
    {
        Debug.Log($"ShowCamera được gọi: {camIndex}");
        switchCamAudio.Play();

        StartCoroutine(FlashStaticRoutine());

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == null)
                continue;

            if (camIndex == 7)
            {
                offlineCamUI.SetActive(true);
            }
            else
            {
                offlineCamUI.SetActive(false);
            }
            cameras[i].gameObject.SetActive(i == camIndex);
        }

        currentCamIndex = camIndex;

    }

    public AnomalyLocation GetCurrentLocation()
    {
        CameraLocation camLoc = cameras[currentCamIndex].GetComponent<CameraLocation>();
        return camLoc.Location;
    }
    private IEnumerator FlashStaticRoutine()
    {
        transitionStaticUI.SetActive(true);    
        yield return new WaitForSeconds(0.1f); 
        transitionStaticUI.SetActive(false);   
    }
}
