using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MageInteract : Menu, IInteractable {

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
       UpdateMageText();
    }

    public void AddMageToTeam(){
        if(!inventory.IsPersonInTeam("Mage") && inventory.GetItemQuantity("Gold") >= 250){
            Inventory.teamMembers.Add("Mage");
            inventory.AddItem("MWeap");
            inventory.AddItem("MArmor");
            inventory.RemoveItem("Gold", 250);
            Debug.Log("Added Mage to your team.");
        }
        else {
            errorCost = true;
            Debug.LogWarning("Mage is already in your team or you don't have enough gold");
        }
    }

    void UpdateMageText(){
        if(inventory != null){
            if(inventory.IsPersonInTeam("Mage")){
                SetGameObjectVisibility(YesButton, false);
                SetGameObjectVisibility(NoButton, false);
                SetGameObjectVisibility(okayButton, true);
                costText.text = "Mage added to your team!";
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
                    costText.text = "Cost 250 gold";
                }
            }
        } 
        else {
            Debug.LogWarning("Inventory is null!");
        }
    }

    public void Interact(){
        Debug.Log("Mage");
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
