using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuActions : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("GamePage1");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
