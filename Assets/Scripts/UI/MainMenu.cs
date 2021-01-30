using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int level1)
    {
        SceneManager.LoadScene(level1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
