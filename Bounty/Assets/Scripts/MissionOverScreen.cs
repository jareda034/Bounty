using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionOverScreen : MonoBehaviour
{
   [Header("Variables")]
   [SerializeField] GameObject missionOverUI;
   public void ShowMissionOver()
    {
        missionOverUI.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Mission 1");
        missionOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        missionOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
