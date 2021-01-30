using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public void ReturnToMenu(int menuIndex)
    {
        SceneManager.LoadScene(menuIndex);
    }
}
