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

    private int rangerArmorLevel = 0;
    private int rangerWeapLevel = 0;
    private int mageArmorLevel = 0;
    private int mageWeapLevel = 0;
    private int knightArmorLevel = 1;
    private int knightWeapLevel = 1;

    public Inventory inventory;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI potionText;

    public TextMeshProUGUI HgoldText;
    public TextMeshProUGUI HpotionText;
    public TextMeshProUGUI frozenHeartsText;

    public GameObject PreHearts;
    public GameObject AfterHearts;

    public TextMeshProUGUI KWeap;
    public TextMeshProUGUI KArmor;

    public TextMeshProUGUI RWeap;
    public TextMeshProUGUI RArmor;

    public TextMeshProUGUI MWeap;
    public TextMeshProUGUI MArmor;

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

    private string level1Text = "Level 1\n";
    private string level2Text = "Level 2\n";
    private string level3Text = "Level 3\n";
    private string level4Text = "Level 4\n";

    private bool hardMode = false;

    void Start(){
        Objects.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        if (inventory.GetItemQuantity("FrozenHearts") > 0) {hardMode = true;}
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
            SetGameObjectVisibility(PreHearts, hardMode == false);
            SetGameObjectVisibility(AfterHearts, hardMode == true);

            int healthPotionQuantity = inventory.GetItemQuantity("Potion");
            potionText.text = healthPotionQuantity.ToString();
            HpotionText.text = healthPotionQuantity.ToString();

            int goldQuantity = inventory.GetItemQuantity("Gold");
            goldText.text = goldQuantity.ToString();
            HgoldText.text = goldQuantity.ToString();

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
        int baseKHealth;
        int baseKArmor;
        string level;

        switch(knightArmorLevel){
            case 1:
                baseKHealth = 35;
                baseKArmor = 20;
                level = level1Text;
                break;
            case 2:
                baseKArmor = 25;
                baseKHealth = 40;
                level = level2Text;
                break;
            case 3:
                baseKArmor = 35;
                baseKHealth = 50;
                level = level3Text;
                break;
            default:
                baseKArmor = 50;
                baseKHealth = 65;
                level = level4Text;
                break;
        }
        level = level + "Armor - " + baseKArmor + "\nHealth - " + baseKHealth;

        KArmor.text = level;

        SetGameObjectVisibility(Klevel1ArmorObject, knightArmorLevel == 1);
        SetGameObjectVisibility(Klevel2ArmorObject, knightArmorLevel == 2);
        SetGameObjectVisibility(Klevel3ArmorObject, knightArmorLevel == 3);
        SetGameObjectVisibility(Klevel4ArmorObject, knightArmorLevel == 4);
    }

    public void UpdateKnightWeapon(int knightWeapLevel){
        int baseKDamage;
        string level;

        switch(knightWeapLevel){
            case 1:
                baseKDamage = 20;
                level = level1Text;
                break;
            case 2:
                baseKDamage = 25;
                level = level2Text;
                break;
            case 3:
                baseKDamage = 35;
                level = level3Text;
                break;
            default:
                baseKDamage = 50;
                level = level4Text;
                break;
        }
        level = level + "Damage - " + baseKDamage;

        KWeap.text = level;

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
        int baseRHealth;
        int baseRArmor;
        string level;

        switch(rangerArmorLevel){
            case 1:
                baseRHealth = 25;
                baseRArmor = 10;
                level = level1Text;
                break;
            case 2:
                baseRArmor = 15;
                baseRHealth = 30;
                level = level2Text;
                break;
            case 3:
                baseRArmor = 25;
                baseRHealth = 40;
                level = level3Text;
                break;
            case 4:
                baseRArmor = 40;
                baseRHealth = 55;
                level = level4Text;
                break;
            default:
                baseRArmor = 0;
                baseRHealth = 0;
                level = "Not Unlocked\n";
                break;
        }
        level = level + "Evade Chance - " + baseRArmor + "\nHealth - " + baseRHealth;

        RArmor.text = level;

        SetGameObjectVisibility(Rlevel0ArmorObject, rangerArmorLevel == 0);
        SetGameObjectVisibility(Rlevel1ArmorObject, rangerArmorLevel == 1);
        SetGameObjectVisibility(Rlevel2ArmorObject, rangerArmorLevel == 2);
        SetGameObjectVisibility(Rlevel3ArmorObject, rangerArmorLevel == 3);
        SetGameObjectVisibility(Rlevel4ArmorObject, rangerArmorLevel == 4);
    }

    public void UpdateRangerWeapon(int rangerWeapLevel){
        int baseRDamage;
        string level;

        switch(rangerWeapLevel){
            case 1:
                baseRDamage = 30;
                level = level1Text;
                break;
            case 2:
                baseRDamage = 35;
                level = level2Text;
                break;
            case 3:
                baseRDamage = 45;
                level = level3Text;
                break;
            case 4:
                baseRDamage = 60;
                level = level4Text;
                break;
            default:
                baseRDamage = 0;
                level = "Not Unlocked\n";
                break;
        }
        level = level + "Damage - " + baseRDamage;

        RWeap.text = level;

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
        int baseMHealth;
        int baseMArmor;
        string level;

        switch(mageArmorLevel){
            case 1:
                baseMHealth = 20;
                baseMArmor = 5;
                level = level1Text;
                break;
            case 2:
                baseMArmor = 10;
                baseMHealth = 25;
                level = level2Text;
                break;
            case 3:
                baseMArmor = 20;
                baseMHealth = 35;
                level = level3Text;
                break;
            case 4:
                baseMArmor = 35;
                baseMHealth = 50;
                level = level4Text;
                break;
            default:
                baseMArmor = 0;
                baseMHealth = 0;
                level = "Not Unlocked\n";
                break;
        }
        level = level + "Extra Damage - " + baseMArmor + "\nHealth - " + baseMHealth;

        MArmor.text = level;

        SetGameObjectVisibility(Mlevel0ArmorObject, mageArmorLevel == 0);
        SetGameObjectVisibility(Mlevel1ArmorObject, mageArmorLevel == 1);
        SetGameObjectVisibility(Mlevel2ArmorObject, mageArmorLevel == 2);
        SetGameObjectVisibility(Mlevel3ArmorObject, mageArmorLevel == 3);
        SetGameObjectVisibility(Mlevel4ArmorObject, mageArmorLevel == 4);
    }

    public void UpdateMageWeapon(int mageWeapLevel){
        int baseMDamage;
        string level;

        switch(mageWeapLevel){
            case 1:
                baseMDamage = 35;
                level = level1Text;
                break;
            case 2:
                baseMDamage = 40;
                level = level2Text;
                break;
            case 3:
                baseMDamage = 50;
                level = level3Text;
                break;
            case 4:
                baseMDamage = 65;
                level = level4Text;
                break;
            default:
                baseMDamage = 0;
                level = "Not Unlocked\n";
                break;
        }
        level = level + "Damage - " + baseMDamage;

        MWeap.text = level;

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
