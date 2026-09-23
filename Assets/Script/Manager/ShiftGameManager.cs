using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftGameManager : MonoBehaviour
{
    [SerializeField] private ShiftClock shiftClock;
    [SerializeField] private WatcherAttack watcherAttack;
    [SerializeField] private GeneratorSystem generatorSystem;
    [SerializeField] private Player player;
    [SerializeField] private OfficeViewManager officeViewManager;
    [SerializeField] private AnomalyManager anomalyManager;

    [Header("UI")]
    [SerializeField] private GameObject winUI; //rawimage
    [SerializeField] private GameObject gameOverUI; //rawimage
    [SerializeField] private GameObject staticNoise; //rawimage
    [SerializeField] private GameObject usagePanel;

    [Header("Start Shift Sequence")]
    [SerializeField] private QuanLyInteract quanLy;             // Lắng nghe Quản lý
    [SerializeField] private PhoneCallController phoneCallController; // Bật cuộc gọi & tiếng quạt

    public static bool startDirectlyInOffice = false;

    [SerializeField] private Transform securityRoomSpawnPoint;

    [SerializeField] private MaintenanceSystem maintenanceSystem;
    [SerializeField] private WinScreenController winScreen;

    [SerializeField] private PowerOutageController powerOutageController;

    [Header("Office Electrical Devices")]
    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;
    [SerializeField] private LightControl leftLight;
    [SerializeField] private LightControl rightLight;

    private void OnEnable()
    {
        shiftClock.shiftCompleted += HandleWin;
        watcherAttack.PlayerCaught += HandleGameOver;

        // THÊM DÒNG NÀY: Nghe tin mất điện bị cắn -> Chạy GameOver luôn!
        if (powerOutageController != null)
            powerOutageController.OnBlackoutKill += HandleGameOver;

        if (quanLy != null)
            quanLy.OnDialogueCompleted += StartOfficeShift;
    }

    private void OnDisable()
    {
        shiftClock.shiftCompleted -= HandleWin;
        watcherAttack.PlayerCaught -= HandleGameOver;

        if (powerOutageController != null)
            powerOutageController.OnBlackoutKill -= HandleGameOver;

        if (quanLy != null)
            quanLy.OnDialogueCompleted -= StartOfficeShift;
    }

    private void Start()
    {
        // Nếu chơi lại (Restart) -> Tự động vào thẳng ghế và bật ca trực luôn
        if (startDirectlyInOffice)
        {
            StartOfficeShift();
        }
        else
        {
            // THÊM DÒNG NÀY: Tắt đồng hồ khi người chơi còn ở ngoài sảnh!
            if (shiftClock != null)
                shiftClock.enabled = false;

            if (usagePanel != null)
                usagePanel.SetActive(false);
        }

        generatorSystem.SetupConsumers(new IPowerConsumer[] { leftDoor, rightDoor, leftLight, rightLight } );
    }

    public void StartOfficeShift()
    {
        // 1. Dịch chuyển vào ghế, bật đồng hồ, máy phát, anomaly...
        SkipToOffice();

        // Bật bảng Usage khi vào phòng trực
        if (usagePanel != null)
            usagePanel.SetActive(true);

        // 2. Kích hoạt tiếng quạt phòng và cuộc gọi Phone Guy
        if (phoneCallController != null)
            phoneCallController.StartNightSequence();
    }
    private void HandleWin()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f; // Tạm dừng trò chơi
        winScreen.StartWinSequence();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (usagePanel != null)
            usagePanel.SetActive(false);
        if (phoneCallController != null)
        {
            phoneCallController.EndCall(false);
            phoneCallController.StopAmbience();
        }
    }

    private void HandleGameOver()
    {
        player.ForceOfficeView();

        var currentView = officeViewManager.CurrentView();

        watcherAttack.PerformJumpscare(currentView);

        if (usagePanel != null)
            usagePanel.SetActive(false);

        if (phoneCallController != null)
        {
            phoneCallController.EndCall(false);
            phoneCallController.StopAmbience();
        }

        StartCoroutine(waitJumpScared());
    }

    private IEnumerator waitJumpScared()
    {
        yield return new WaitForSeconds(1.75f); // đợi jump

        staticNoise.SetActive(true);

        yield return new WaitForSeconds(1.75f); // staticnoise

        staticNoise.SetActive(false);

        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Tạm dừng trò chơi

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartShift()
    {
        Time.timeScale = 1f;
        startDirectlyInOffice = true; // Đánh dấu: "Lần sau load lại game là vào thẳng văn phòng!"
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SkipToOffice()
    {
        // 1. Dịch chuyển Player vào đúng cái ghế trong phòng bảo vệ
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.position = securityRoomSpawnPoint.position;
            rb.rotation = securityRoomSpawnPoint.rotation;
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            player.transform.position = securityRoomSpawnPoint.position;
            player.transform.rotation = securityRoomSpawnPoint.rotation;
        }
        // 2. Chỉnh mặt nhìn thẳng và khóa vào ghế
        officeViewManager.ResetToFront();
        player.EnterOffice();
        // 3. Kích hoạt ca trực
        shiftClock.enabled = true;
        anomalyManager.StartShift();
        generatorSystem.StartGeneratorAfterDelay(45f);
    }

}
