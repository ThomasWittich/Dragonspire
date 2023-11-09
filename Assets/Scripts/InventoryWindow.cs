using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryWindow : Menu
{
    public GameObject Objects;
    public bool isPaused;
    private bool canProcess = false;

    public Inventory inventory;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI potionText;
    public TextMeshProUGUI frozenHeartsText;

    public int rangerArmorLevel = 0;
    public int rangerWeapLevel = 0;
    public int mageArmorLevel = 0;
    public int mageWeapLevel = 0;
    public int knightArmorLevel = 1;
    public int knightWeapLevel = 1;

    public GameObject Klevel1WeaponObject;
    public GameObject Klevel2WeaponObject;
    public GameObject Klevel3WeaponObject;
    public GameObject Klevel4WeaponObject;

    public GameObject Klevel1ArmorObject;
    public GameObject Klevel2ArmorObject;
    public GameObject Klevel3ArmorObject;
    public GameObject Klevel4ArmorObject;

    public GameObject Rlevel0WeaponObject;
    public GameObject Rlevel1WeaponObject;
    public GameObject Rlevel2WeaponObject;
    public GameObject Rlevel3WeaponObject;
    public GameObject Rlevel4WeaponObject;

    public GameObject Rlevel0ArmorObject;
    public GameObject Rlevel1ArmorObject;
    public GameObject Rlevel2ArmorObject;
    public GameObject Rlevel3ArmorObject;
    public GameObject Rlevel4ArmorObject;

    public GameObject Mlevel0WeaponObject;
    public GameObject Mlevel1WeaponObject;
    public GameObject Mlevel2WeaponObject;
    public GameObject Mlevel3WeaponObject;
    public GameObject Mlevel4WeaponObject;

    public GameObject Mlevel0ArmorObject;
    public GameObject Mlevel1ArmorObject;
    public GameObject Mlevel2ArmorObject;
    public GameObject Mlevel3ArmorObject;
    public GameObject Mlevel4ArmorObject;

    void Start(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            if(isPaused){
                ExitInventory();
            }
            else {
                OpenInventory();
                UpdateInventoryText();
            }
        }
        if(canProcess && Input.GetKeyDown(KeyCode.Escape)){
            ExitInventory();
       }
    }

    public void OpenInventory(){
        Objects.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenusClosed = false;
        canProcess = true;
    }

    public void ExitInventory(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenusClosed = true;
        canProcess = false;
    }

    public void UpdateInventoryText(){
        UpdateInventoryNorm();
        UpdateKnightInventoryText();
        UpdateMageInventoryText();
        UpdateRangerInventoryText();
    }

    public void UpdateInventoryNorm(){
        int healthPotionQuantity = inventory.GetItemQuantity("Potion");
       potionText.text = healthPotionQuantity.ToString();

       int goldQuantity = inventory.GetItemQuantity("Gold");
       goldText.text = goldQuantity.ToString();

       int frozenHeartsQuantity = inventory.GetItemQuantity("FrozenHearts");
       frozenHeartsText.text = frozenHeartsQuantity.ToString();
    }

    public void UpdateKnightInventoryText(){
        knightWeapLevel = inventory.GetItemLevel("KWeap");
        knightArmorLevel = inventory.GetItemLevel("KArmor");
        
        UpdateKnightArmor(knightArmorLevel);
        UpdateKnightWeapon(knightWeapLevel);        
    }

    public void UpdateKnightArmor(int knightArmorLevel){

        SetGameObjectVisibility(Klevel1ArmorObject, knightArmorLevel == 1);
        SetGameObjectVisibility(Klevel2ArmorObject, knightArmorLevel == 2);
        SetGameObjectVisibility(Klevel3ArmorObject, knightArmorLevel == 3);
        SetGameObjectVisibility(Klevel4ArmorObject, knightArmorLevel == 4);
    }

    public void UpdateKnightWeapon(int knightWeapLevel){

        SetGameObjectVisibility(Klevel1WeaponObject, knightWeapLevel == 1);
        SetGameObjectVisibility(Klevel2WeaponObject, knightWeapLevel == 2);
        SetGameObjectVisibility(Klevel3WeaponObject, knightWeapLevel == 3);
        SetGameObjectVisibility(Klevel4WeaponObject, knightWeapLevel == 4);
    }

    public void UpdateRangerInventoryText(){
        bool inTeam = inventory.IsPersonInTeam("Ranger");
        if(inTeam){
            rangerWeapLevel = inventory.GetItemLevel("RWeap");
            rangerArmorLevel = inventory.GetItemLevel("RArmor");
        }
        else{
            rangerWeapLevel= 0;
            rangerArmorLevel = 0;
        }
        UpdateRangerArmor(rangerArmorLevel);
        UpdateRangerWeapon(rangerWeapLevel);
    }

    public void UpdateRangerArmor(int rangerArmorLevel){

        SetGameObjectVisibility(Rlevel0ArmorObject, rangerArmorLevel == 0);
        SetGameObjectVisibility(Rlevel1ArmorObject, rangerArmorLevel == 1);
        SetGameObjectVisibility(Rlevel2ArmorObject, rangerArmorLevel == 2);
        SetGameObjectVisibility(Rlevel3ArmorObject, rangerArmorLevel == 3);
        SetGameObjectVisibility(Rlevel4ArmorObject, rangerArmorLevel == 4);
    }

    public void UpdateRangerWeapon(int rangerWeapLevel){

        SetGameObjectVisibility(Rlevel0WeaponObject, rangerWeapLevel == 0);
        SetGameObjectVisibility(Rlevel1WeaponObject, rangerWeapLevel == 1);
        SetGameObjectVisibility(Rlevel2WeaponObject, rangerWeapLevel == 2);
        SetGameObjectVisibility(Rlevel3WeaponObject, rangerWeapLevel == 3);
        SetGameObjectVisibility(Rlevel4WeaponObject, rangerWeapLevel == 4);
    }

    public void UpdateMageInventoryText(){
        bool inTeam = inventory.IsPersonInTeam("Mage");
        if(inTeam){
            mageArmorLevel = inventory.GetItemLevel("MWeap");
            mageWeapLevel = inventory.GetItemLevel("MArmor");
        }
        else{
            mageWeapLevel = 0;
            mageArmorLevel = 0;
        }
        UpdateMageArmor(mageWeapLevel);
        UpdateMageWeapon(mageArmorLevel);
    }

    public void UpdateMageArmor(int mageArmorLevel){

        SetGameObjectVisibility(Mlevel0ArmorObject, mageArmorLevel == 0);
        SetGameObjectVisibility(Mlevel1ArmorObject, mageArmorLevel == 1);
        SetGameObjectVisibility(Mlevel2ArmorObject, mageArmorLevel == 2);
        SetGameObjectVisibility(Mlevel3ArmorObject, mageArmorLevel == 3);
        SetGameObjectVisibility(Mlevel4ArmorObject, mageArmorLevel == 4);
    }

    public void UpdateMageWeapon(int mageWeapLevel){
        SetGameObjectVisibility(Mlevel0WeaponObject, mageWeapLevel == 0);
        SetGameObjectVisibility(Mlevel1WeaponObject, mageWeapLevel == 1);
        SetGameObjectVisibility(Mlevel2WeaponObject, mageWeapLevel == 2);
        SetGameObjectVisibility(Mlevel3WeaponObject, mageWeapLevel == 3);
        SetGameObjectVisibility(Mlevel4WeaponObject, mageWeapLevel == 4);
    }

    private void SetGameObjectVisibility(GameObject go, bool isVisible)
    {
        if (go != null)
        {
            go.SetActive(isVisible);
        }
    }

}
