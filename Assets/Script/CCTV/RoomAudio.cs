using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        // Hễ Cam này được kích hoạt Active -> Tự phát tiếng
        if (audioSource != null) audioSource.Play();
    }

    private void OnDisable()
    {
        // Hễ Cam này bị tắt (hoặc chuyển cam khác) -> Tự ngắt tiếng
        if (audioSource != null) audioSource.Stop();
    }
}