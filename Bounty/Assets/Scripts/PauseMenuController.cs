using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] GameObject menu;
    [Header("Menu Settings")]
    bool menuOpen = false;

    public void OpenMenu()
    {
        if(menuOpen){ return; }
        menu.SetActive(true);
        menuOpen = true;
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        menuOpen = false;
        Time.timeScale =1f;
    }

    public void Exit()
    {
       SceneManager.LoadScene("MainMenu");
    }

    public bool GetMenuOpen()
    {
        return menuOpen;
    }
}
