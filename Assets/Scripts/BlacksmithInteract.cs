using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlacksmithInteract : Menu, IInteractable
{
    public GameObject Objects;
    public bool isPaused;
    private static bool canProcess = false;

    public Inventory inventory;

    public GameObject InsufficientFundsPage;
    public GameObject MaxPotions;

    public TextMeshProUGUI coins;
    public TextMeshProUGUI potions;

    public TextMeshProUGUI KWeap;
    public TextMeshProUGUI KArmor;
    public GameObject KWButton;
    public GameObject KAButton;

    public TextMeshProUGUI RWeap;
    public TextMeshProUGUI RArmor;
    public GameObject RWButton;
    public GameObject RAButton;

    public TextMeshProUGUI MWeap;
    public TextMeshProUGUI MArmor;
    public GameObject MWButton;
    public GameObject MAButton;

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

    private int rangerArmorLevel;
    private int rangerWeapLevel;
    private int mageArmorLevel;
    private int mageWeapLevel;
    private int knightArmorLevel;
    private int knightWeapLevel;

    private string level1Text = "Unlock Character First";
    private string level2Text = "Level 2 - 50 Gold\n+5";
    private string level3Text = "Level 3 - 100 Gold\n+10";
    private string level4Text = "Level 4 - 200 Gold\n+15";
    private string fullyUpgradedText = "Item is fully Upgraded!";

    void Start(){
        InsufficientFundsPage.SetActive(false);
        MaxPotions.SetActive(false);
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
       UpdateBlacksmithIcons();
    }

    void UpdateBlacksmithIcons(){
        UpdateInventoryNorm();
        UpdateKnightInventoryText();
        UpdateMageInventoryText();
        UpdateRangerInventoryText();
    }

    void MaxPotionsPage(){
        canProcess = false;
        MaxPotions.SetActive(true);
    }

    public void CloseMaxPotions(){
        canProcess = true;
        MaxPotions.SetActive(false);
    }

    void InsufficientGold(){
        canProcess = false;
        InsufficientFundsPage.SetActive(true);
    }

    public void CloseInsufficientGold(){
        canProcess = true;
        InsufficientFundsPage.SetActive(false);
    }

    void UpdateInventoryNorm(){
        int goldQuantity = inventory.GetItemQuantity("Gold");
        coins.text = goldQuantity.ToString();

        int potionQuantity = inventory.GetItemQuantity("Potion");
        potions.text = potionQuantity.ToString();
    }

    public void BuyPotion(){
        if(inventory.GetItemQuantity("Potion") < 10){
            if(inventory.GetItemQuantity("Gold") >= 15){
                inventory.RemoveItem("Gold", 15);
                inventory.AddItem("Potion");

                Debug.Log("1 Potion Added");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for potion");
            }
        } else {
            MaxPotionsPage();
            Debug.Log("Maxxed out on potions");
        }
    }

    public void BuyMaxPotion(){
        if(inventory.GetItemQuantity("Potion") < 10){
            int potionAmount = inventory.GetItemQuantity("Potion");
            int potionsNeeded = 10 - potionAmount;
            int maxCost = (10 - potionAmount) * 15;
            if(inventory.GetItemQuantity("Gold") > maxCost){
                inventory.RemoveItem("Gold", maxCost);
                inventory.AddItem("Potion", potionsNeeded);

                Debug.Log(potionsNeeded + " Potion Added");
            } else {
                InsufficientGold();
                Debug.Log("Not enough gold for potion");
            }
        } else {
            MaxPotionsPage();
            Debug.Log("Maxxed out on potions");
        }
    }

    public int CalculateUpgrade(int currentItemLevel){
        if(currentItemLevel == 3){
            return 200;
        } else {
            return currentItemLevel * 50;
        }
    }

    public void UpgradeKnightArmor(){
        int currentKnightArmorLevel = inventory.GetItemLevel("KArmor");
        int upgradeCost = CalculateUpgrade(currentKnightArmorLevel);
        if (currentKnightArmorLevel < 4){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("KArmor");
                inventory.AddItem("KArmor", 1, currentKnightArmorLevel+1);

                Debug.Log("Knight armor upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level");
        }
    }

    public void UpgradeKnightWeapon(){
        int currentKnightWeaponLevel = inventory.GetItemLevel("KWeap");
        int upgradeCost = CalculateUpgrade(currentKnightWeaponLevel);
        if (currentKnightWeaponLevel < 4){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("KWeap");
                inventory.AddItem("KWeap", 1, currentKnightWeaponLevel+1);

                Debug.Log("Knight weapon upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level");
        }
    }

    public void UpgradeRangerArmor(){
        int currentRangerArmorLevel = inventory.GetItemLevel("RArmor");
        int upgradeCost = CalculateUpgrade(currentRangerArmorLevel);
        if(currentRangerArmorLevel < 4 && inventory.IsPersonInTeam("Ranger")){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("RArmor");
                inventory.AddItem("RArmor", 1, currentRangerArmorLevel+1);

                Debug.Log("Ranger armor upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level or character not unlocked");
        }
    }

    public void UpgradeRangerWeapon(){
        int currentRangerWeaponLevel = inventory.GetItemLevel("RWeap");
        int upgradeCost = CalculateUpgrade(currentRangerWeaponLevel);
        if(currentRangerWeaponLevel < 4 && inventory.IsPersonInTeam("Ranger")){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("RWeap");
                inventory.AddItem("RWeap", 1, currentRangerWeaponLevel+1);

                Debug.Log("Ranger weapon upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level or character not unlocked");
        }
    }

    public void UpgradeMageArmor(){
        int currentMageArmorLevel = inventory.GetItemLevel("MArmor");
        int upgradeCost = CalculateUpgrade(currentMageArmorLevel);
        if(currentMageArmorLevel < 4 && inventory.IsPersonInTeam("Mage")){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("MArmor");
                inventory.AddItem("MArmor", 1, currentMageArmorLevel+1);

                Debug.Log("Mage armor upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level or character not unlocked");
        }
    }

    public void UpgradeMageWeapon(){
        int currentMageWeaponLevel = inventory.GetItemLevel("MWeap");
        int upgradeCost = CalculateUpgrade(currentMageWeaponLevel);
        if(currentMageWeaponLevel < 4 && inventory.IsPersonInTeam("Mage")){
            if(inventory.GetItemQuantity("Gold") >= upgradeCost){
                inventory.RemoveItem("Gold", upgradeCost);
                inventory.RemoveItem("MWeap");
                inventory.AddItem("MWeap", 1, currentMageWeaponLevel+1);

                Debug.Log("Mage weapon upgraded");
            }
            else {
                InsufficientGold();
                Debug.Log("Not enough gold for upgrade");
            }
        } else {
            Debug.Log("Item at max level or character not unlocked");
        }
    }

    public void UpdateKnightInventoryText(){
        knightWeapLevel = inventory.GetItemLevel("KWeap");
        knightArmorLevel = inventory.GetItemLevel("KArmor");
        
        UpdateKnightArmor(knightArmorLevel);
        UpdateKnightWeapon(knightWeapLevel);        
    }

    public void UpdateKnightArmor(int knightArmorLevel){
        string additive = " armor & health";
        switch(knightArmorLevel){
            case 1:
                KArmor.text = level2Text + additive;
                break;
            case 2:
                KArmor.text = level3Text + additive;
                break;
            case 3:
                KArmor.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(KAButton,false);
                KArmor.text = fullyUpgradedText;
                break;
        }

        SetGameObjectVisibility(Klevel1ArmorObject, knightArmorLevel == 1);
        SetGameObjectVisibility(Klevel2ArmorObject, knightArmorLevel == 2);
        SetGameObjectVisibility(Klevel3ArmorObject, knightArmorLevel == 3);
        SetGameObjectVisibility(Klevel4ArmorObject, knightArmorLevel == 4);
    }

    public void UpdateKnightWeapon(int knightWeapLevel){
        string additive = " damage";
        switch(knightWeapLevel){
            case 1:
                KWeap.text = level2Text + additive;
                break;
            case 2:
                KWeap.text = level3Text + additive;
                break;
            case 3:
                KWeap.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(KWButton,false);
                KWeap.text = fullyUpgradedText;
                break;
        }

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
        string additive = " evade chance & health";
        switch(rangerArmorLevel){
            case 0:
                RArmor.text = level1Text;
                break;
            case 1:
                RArmor.text = level2Text + additive;
                break;
            case 2:
                RArmor.text = level3Text + additive;
                break;
            case 3:
                RArmor.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(RAButton,false);
                RArmor.text = fullyUpgradedText;
                break;
        }

        SetGameObjectVisibility(Rlevel0ArmorObject, rangerArmorLevel == 0);
        SetGameObjectVisibility(Rlevel1ArmorObject, rangerArmorLevel == 1);
        SetGameObjectVisibility(Rlevel2ArmorObject, rangerArmorLevel == 2);
        SetGameObjectVisibility(Rlevel3ArmorObject, rangerArmorLevel == 3);
        SetGameObjectVisibility(Rlevel4ArmorObject, rangerArmorLevel == 4);
    }

    public void UpdateRangerWeapon(int rangerWeapLevel){
        string additive = " damage";
        switch(rangerWeapLevel){
            case 0:
                RWeap.text = level1Text;
                break;
            case 1:
                RWeap.text = level2Text + additive;
                break;
            case 2:
                RWeap.text = level3Text + additive;
                break;
            case 3:
                RWeap.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(RWButton,false);
                RWeap.text = fullyUpgradedText;
                break;
        }

        SetGameObjectVisibility(Rlevel0WeaponObject, rangerWeapLevel == 0);
        SetGameObjectVisibility(Rlevel1WeaponObject, rangerWeapLevel == 1);
        SetGameObjectVisibility(Rlevel2WeaponObject, rangerWeapLevel == 2);
        SetGameObjectVisibility(Rlevel3WeaponObject, rangerWeapLevel == 3);
        SetGameObjectVisibility(Rlevel4WeaponObject, rangerWeapLevel == 4);
    }

    public void UpdateMageInventoryText(){
        bool inTeam = inventory.IsPersonInTeam("Mage");
        if(inTeam){
            mageArmorLevel = inventory.GetItemLevel("MArmor");
            mageWeapLevel = inventory.GetItemLevel("MWeap");
        }
        else{
            mageWeapLevel = 0;
            mageArmorLevel = 0;
        }
        UpdateMageArmor(mageArmorLevel);
        UpdateMageWeapon(mageWeapLevel);
    }

    public void UpdateMageArmor(int mageArmorLevel){
        string additive = " damage & health";
        switch(mageArmorLevel){
            case 0:
                MArmor.text = level1Text;
                break;
            case 1:
                MArmor.text = level2Text + additive;
                break;
            case 2:
                MArmor.text = level3Text + additive;
                break;
            case 3:
                MArmor.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(MAButton,false);
                MArmor.text = fullyUpgradedText;
                break;
        }

        SetGameObjectVisibility(Mlevel0ArmorObject, mageArmorLevel == 0);
        SetGameObjectVisibility(Mlevel1ArmorObject, mageArmorLevel == 1);
        SetGameObjectVisibility(Mlevel2ArmorObject, mageArmorLevel == 2);
        SetGameObjectVisibility(Mlevel3ArmorObject, mageArmorLevel == 3);
        SetGameObjectVisibility(Mlevel4ArmorObject, mageArmorLevel == 4);
    }

    public void UpdateMageWeapon(int mageWeapLevel){
        string additive = " damage";
        switch(mageWeapLevel){
            case 0:
                MWeap.text = level1Text;
                break;
            case 1:
                MWeap.text = level2Text + additive;
                break;
            case 2:
                MWeap.text = level3Text + additive;
                break;
            case 3:
                MWeap.text = level4Text + additive;
                break;
            default:
                SetGameObjectVisibility(MWButton,false);
                MWeap.text = fullyUpgradedText;
                break;
        }

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

    public void Interact(){
        Debug.Log("Blacksmith");
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
    }
}
