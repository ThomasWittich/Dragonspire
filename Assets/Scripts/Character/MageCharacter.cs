using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageCharacter : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float dot;
    public float damage;

    private Inventory inventory;

    public KnightCharacter knight;
    public RangerCharacter ranger;

    private int armLev;
    private int weapLev;

    private void Start()
    {
        inventory = StaticData.globalInventory;
        weapLev = inventory.GetItemLevel("MWeap");
        armLev = inventory.GetItemLevel("MArmor");
        switch(armLev){
            case 1:
                maxHealth = 20;
                dot = 5;
                break;
            case 2:
                maxHealth = 25;
                dot = 10;
                break;
            case 3:
                maxHealth = 35;
                dot = 20;
                break;
            default:
                maxHealth = 50;
                dot = 35;
                break;
        }
        switch(weapLev){
            case 1:
                damage = 35;
                break;
            case 2:
                damage = 40;
                break;
            case 3:
                damage = 50;
                break;
            default:
                damage = 65;
                break;
        }
    }

    public float basicAttack(){
        return damage;
    }

    public float multiAttack(){
        return damage/3;
    }

    public void partyHeal(){
        inventory.RemoveItem("Potion");
        Heal(true);
        knight.Heal(true);
        ranger.Heal(true);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

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
