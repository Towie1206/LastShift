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
    

    public static bool startDirectlyInOffice = false;

    [SerializeField] private Transform securityRoomSpawnPoint;

    [SerializeField] private MaintenanceSystem maintenanceSystem;
    [SerializeField] private WinScreenController winScreen;

    private void OnEnable()
    {
        shiftClock.shiftCompleted += HandleWin;
        watcherAttack.PlayerCaught += HandleGameOver;

        // Thêm dòng này: Hết oxy ngạt thở -> Game Over!
        if (maintenanceSystem != null)
            maintenanceSystem.VentilationExpired += HandleGameOver;
    }

    private void OnDisable()
    {
        shiftClock.shiftCompleted -= HandleWin;
        watcherAttack.PlayerCaught -= HandleGameOver;

        if (maintenanceSystem != null)
            maintenanceSystem.VentilationExpired -= HandleGameOver;
    }



    private void Start()
    {
        // Nếu lần chơi trước vừa bấm Restart -> Nhảy cóc thẳng vào ghế bảo vệ!
        if (startDirectlyInOffice)
        {
            SkipToOffice();
        }
    }
    private void HandleWin()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f; // Tạm dừng trò chơi
        winScreen.StartWinSequence();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HandleGameOver()
    {
        player.ForceOfficeView();

        var currentView = officeViewManager.CurrentView();

        watcherAttack.PerformJumpscare(currentView);

        StartCoroutine(waitJumpScared());
    }

    private IEnumerator waitJumpScared()
    {
        yield return new WaitForSeconds(2f);

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
