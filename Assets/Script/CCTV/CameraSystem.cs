using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private RenderTexture outputTexture;
    [SerializeField] private int startingCameraIndex;
    public int currentCamIndex { get; private set; }

    private void Awake()
    {
        if (cameras == null || cameras.Length == 0)
            return;

        if (outputTexture == null)
            return;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == null)
            {
                Debug.LogWarning("Camera at index " + i + " is null.");
                continue;
            }    

            cameras[i].targetTexture = outputTexture;
            cameras[i].gameObject.SetActive(false);

        }
        currentCamIndex = startingCameraIndex;

        ShowCamera(currentCamIndex);
    }

    public void ShowCamera(int camIndex)
    {
        Debug.Log($"ShowCamera được gọi: {camIndex}");

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == null)
                continue;

            cameras[i].gameObject.SetActive(i == camIndex);
        }

        currentCamIndex = camIndex;
    }

}
