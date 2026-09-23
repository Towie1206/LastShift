using System.Collections;
using UnityEngine;
using TMPro;

public class PhoneCallController : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource officeAmbienceAudio;
    [SerializeField] private AudioSource ringAudio;       // fnaf-phone-ringing-sound
    [SerializeField] private AudioSource phoneGuyAudio;   // PhoneGuy.wav
    [SerializeField] private AudioSource hangUpAudio;     // phone-guy-hang-up

    [Header("UI Elements")]
    [SerializeField] private GameObject muteCallButton;   // Nút [MUTE CALL]
    [SerializeField] private GameObject subtitlePanel;    // Khung chứa chữ phụ đề
    [SerializeField] private TMP_Text subtitleText;// Chữ hiển thị lời thoại

    [Header("Settings")]
    [SerializeField] private float delayBeforeRinging = 1.5f;
    [SerializeField] private float ringDuration = 13.345f; // Reo trong bao lâu thì tự nhấc máy

    // Dữ liệu Subtitle: Thời gian xuất hiện và câu thoại
    [System.Serializable]
    public struct SubtitleLine
    {
        public float timeOffset; // Giây thứ bao nhiêu từ lúc bắt đầu nói
        [TextArea(2, 4)] public string text;
    }

    [SerializeField] private SubtitleLine[] subtitles;

    private Coroutine callRoutine;
    private Coroutine subtitleCoroutine;
    private bool isCallActive;

    public void StartNightSequence()
    {
        // 1. Bật ngay tiếng quạt phòng
        if (officeAmbienceAudio != null && !officeAmbienceAudio.isPlaying)
            officeAmbienceAudio.Play();
        // 2. Chạy chuỗi cuộc gọi
        if (callRoutine != null) StopCoroutine(callRoutine);
        callRoutine = StartCoroutine(CallRoutine());
    }

    private IEnumerator CallRoutine()
    {
        if (muteCallButton != null) muteCallButton.SetActive(false);
        if (subtitlePanel != null) subtitlePanel.SetActive(false);

        // 1. Đợi một chút rồi đổ chuông
        yield return new WaitForSeconds(delayBeforeRinging);
        if (ringAudio != null) ringAudio.Play();

        // 2. Chuông reo trong vài giây
        yield return new WaitForSeconds(ringDuration);
        if (ringAudio != null) ringAudio.Stop();

        // 3. Tự động nhấc máy và phát đoạn thoại
        isCallActive = true;
        if (phoneGuyAudio != null) phoneGuyAudio.Play();

        if (muteCallButton != null) muteCallButton.SetActive(true);
        if (subtitlePanel != null) subtitlePanel.SetActive(true);

        // Chạy phụ đề đồng bộ với giọng nói
        subtitleCoroutine = StartCoroutine(RunSubtitles());

        // Đợi cho đến khi phát xong hết đoạn ghi âm
        if (phoneGuyAudio != null && phoneGuyAudio.clip != null)
            yield return new WaitForSeconds(phoneGuyAudio.clip.length);

        EndCall(true);
    }

    private IEnumerator RunSubtitles()
    {
        float timer = 0f;
        int currentLine = 0;

        while (isCallActive && currentLine < subtitles.Length)
        {
            if (timer >= subtitles[currentLine].timeOffset)
            {
                if (subtitleText != null)
                    subtitleText.text = subtitles[currentLine].text;
                currentLine++;
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }

    // Hàm này gán vào sự kiện OnClick của nút [MUTE CALL] trên UI
    public void OnMuteCallClicked()
    {
        EndCall(true);
    }

    public void EndCall(bool playHangUpSound = true)
    {
        isCallActive = false;

        // Dừng tất cả coroutine
        if (callRoutine != null)
        {
            StopCoroutine(callRoutine);
            callRoutine = null;
        }
        if (subtitleCoroutine != null)
        {
            StopCoroutine(subtitleCoroutine);
            subtitleCoroutine = null;
        }

        // Dừng âm thanh chuông và tiếng Phone Guy
        if (ringAudio != null && ringAudio.isPlaying) ringAudio.Stop();
        if (phoneGuyAudio != null && phoneGuyAudio.isPlaying) phoneGuyAudio.Stop();

        // Phát tiếng cúp máy nếu được yêu cầu
        if (playHangUpSound && hangUpAudio != null)
        {
            hangUpAudio.Play();
        }
        else if (hangUpAudio != null && hangUpAudio.isPlaying)
        {
            hangUpAudio.Stop();
        }

        // Tắt UI
        if (muteCallButton != null) muteCallButton.SetActive(false);
        if (subtitlePanel != null) subtitlePanel.SetActive(false);
    }

    public void StopAmbience()
    {
        if (officeAmbienceAudio != null && officeAmbienceAudio.isPlaying)
            officeAmbienceAudio.Stop();
    }
}