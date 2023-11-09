using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : Menu
{
    public GameObject Objects;
    public bool isPaused;
    private bool canProcess = false;

    void Start(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        if(canProcess && Input.GetKeyDown(KeyCode.Escape)){
            ExitControls();
       }
    }

    public void OpenControls(){
        Objects.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenusClosed = false;
        canProcess = true;
    }

    public void ExitControls(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenusClosed = true;
        canProcess = false;
    }
}
