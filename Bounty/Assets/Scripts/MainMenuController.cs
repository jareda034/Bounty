using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Mission 1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
