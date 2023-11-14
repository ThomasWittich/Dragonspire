using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu
{
    public GameObject Objects;
    public static bool isPaused;

    void Start(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        if(MenusClosed == true && Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                UnPauseGame();
            }
            else {
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        Objects.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnPauseGame(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hub World");
    }

    public void QuitButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void HelpButton(){
        UnPauseGame();
    }

    public void ControlsButton(){
        UnPauseGame();
    }
}
