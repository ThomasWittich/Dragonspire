using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerCharacter : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float evadechance;
    public float damage;

    private bool dodge = false;

    private Inventory inventory;

    private int armLev;
    private int weapLev;

    private void Start()
    {
        inventory = StaticData.globalInventory;
        weapLev = inventory.GetItemLevel("RWeap");
        armLev = inventory.GetItemLevel("RArmor");
        switch(armLev){
            case 1:
                maxHealth = 25;
                evadechance = 10;
                break;
            case 2:
                maxHealth = 30;
                evadechance = 15;
                break;
            case 3:
                maxHealth = 40;
                evadechance = 25;
                break;
            default:
                maxHealth = 55;
                evadechance = 40;
                break;
        }
        switch(weapLev){
            case 1:
                damage = 30;
                break;
            case 2:
                damage = 35;
                break;
            case 3:
                damage = 45;
                break;
            default:
                damage = 60;
                break;
        }
    }

    public float basicAttack(){
        return damage;
    }

    public float multiAttack(){
        return damage/3;
    }

    public float piercingShot(){
        return damage;
    }

    public void TakeDamage(float damage)
    {
        dodge = CalculateDodge(evadechance);
        if (dodge == false){
            currentHealth -= damage;
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
    }

    public bool CalculateDodge(float dodgeValue)
    {
        dodgeValue = Mathf.Clamp(dodgeValue, 1, 100);
        int randomNum = Random.Range(1, 101);
        return randomNum <= dodgeValue;
    }

    public void Heal(bool partyHeal = false)
    {
        if(partyHeal){
            currentHealth = Mathf.Min(currentHealth + (maxHealth * .2f), maxHealth);
        } else {
            currentHealth = Mathf.Min(currentHealth + (maxHealth * .2f), maxHealth);
            inventory.RemoveItem("Potion");
        }
        
    }
}
