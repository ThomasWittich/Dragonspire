using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : Menu
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
        if(Input.GetKeyDown(KeyCode.H)){
            if(isPaused){
                ExitHelp();
            }
            else {
                OpenHelp();
            }
        }
        if(canProcess && Input.GetKeyDown(KeyCode.Escape)){
            ExitHelp();
       }
    }

    public void OpenHelp(){
        Objects.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenusClosed = false;
        canProcess = true;
    }

    public void ExitHelp(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenusClosed = true;
        canProcess = false;
    }
}
