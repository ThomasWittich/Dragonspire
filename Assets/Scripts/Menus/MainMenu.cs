using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    public GameObject Objects;
    public static bool isPaused;

    void Start(){
        Objects.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update(){
    }

    public void PlayGame(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub World");
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void HelpButton(){
    }
}
