using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RangerInteract : Menu, IInteractable
{
    public GameObject Objects;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject okayButton;
    public TextMeshProUGUI costText;
    public Inventory inventory;

    private static bool errorCost;
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
        ExitInteract();
       }
       UpdateRangerText();
    }

    public void AddRangerToTeam(){
        if(!inventory.IsPersonInTeam("Ranger") && inventory.GetItemQuantity("Gold") > 100){
            Inventory.teamMembers.Add("Ranger");
            inventory.AddItem("RWeap");
            inventory.AddItem("RArmor");
            inventory.RemoveItem("Gold", 100);
            Debug.Log("Added Ranger to your team.");
        }
        else {
            errorCost = true;
            Debug.LogWarning("Ranger is already in your team or you don't have enough gold");
        }
    }

    void UpdateRangerText(){
        if(inventory != null){
            if(inventory.IsPersonInTeam("Ranger")){
                SetGameObjectVisibility(YesButton, false);
                SetGameObjectVisibility(NoButton, false);
                SetGameObjectVisibility(okayButton, true);
                costText.text = "Ranger added to your team!";
            }
            else {
                if(errorCost){
                    SetGameObjectVisibility(YesButton, false);
                    SetGameObjectVisibility(NoButton, false);
                    SetGameObjectVisibility(okayButton, true);
                    costText.text = "Not enough gold";
                } else {
                    SetGameObjectVisibility(YesButton, true);
                    SetGameObjectVisibility(NoButton, true);
                    SetGameObjectVisibility(okayButton, false);
                    costText.text = "Cost 100 gold";
                }
            }
        } 
        else {
            Debug.LogWarning("Inventory is null!");
        }
    }

    public void Interact(){
        Debug.Log("Ranger");
        Objects.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenusClosed = false;
        canProcess = true;
    }

    public void ExitInteract(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenusClosed = true;
        canProcess = false;
        errorCost = false;
    }

    private void SetGameObjectVisibility(GameObject go, bool isVisible)
    {
        if (go != null)
        {
            go.SetActive(isVisible);
        }
    }
}
