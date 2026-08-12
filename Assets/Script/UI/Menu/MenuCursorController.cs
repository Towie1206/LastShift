using UnityEngine;

    /// <summary>
    /// Chịu trách nhiệm duy nhất: đảm bảo cursor hiển thị và không bị khóa trong Main Menu.
    /// </summary>
    public class MenuCursorController : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }