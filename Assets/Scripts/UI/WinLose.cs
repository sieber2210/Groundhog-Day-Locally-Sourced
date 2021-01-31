using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReturnToMenu(int menuIndex)
    {
        SceneManager.LoadScene(menuIndex);
    }
}
