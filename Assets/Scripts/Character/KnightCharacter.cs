using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCharacter : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float armor;
    public float damage;

    private Inventory inventory;

    public bool aggro;

    private int armLev;
    private int weapLev;

    private void Start()
    {
        inventory = StaticData.globalInventory;
        weapLev = inventory.GetItemLevel("KWeap");
        armLev = inventory.GetItemLevel("KArmor");
        switch(armLev){
            case 1:
                maxHealth = 35;
                armor = 20;
                break;
            case 2:
                maxHealth = 40;
                armor = 25;
                break;
            case 3:
                maxHealth = 50;
                armor = 35;
                break;
            default:
                maxHealth = 65;
                armor = 50;
                break;
        }
        switch(weapLev){
            case 1:
                damage = 20;
                break;
            case 2:
                damage = 25;
                break;
            case 3:
                damage = 35;
                break;
            default:
                damage = 50;
                break;
        }
    }

    public float basicAttack(){
        return damage;
    }

    public float multiAttack(){
        return damage/3;
    }

    public void taunt(){
        armor += 20;
        aggro = true;
    }

    public void TakeDamage(float damage, bool pierce)
    {
        if (pierce == false){
            float damageAfterArmor = Mathf.Max(damage - armor, 0f);
            currentHealth -= damageAfterArmor;
        }
        else {
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
