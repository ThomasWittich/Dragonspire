using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : Menu
{
    public GameObject Objects;
    public bool isPaused;
    private bool canProcess = false;

    void Start(){
        Objects.SetActive(false);
    }

    void Update(){
        if(canProcess && Input.GetKeyDown(KeyCode.Escape)){
            ExitHelp();
       }
    }

    public void OpenHelp(){
        Objects.SetActive(true);
        MenusClosed = false;
        canProcess = true;
    }

    public void ExitHelp(){
        Objects.SetActive(false);
        MenusClosed = true;
        canProcess = false;
    }
}
