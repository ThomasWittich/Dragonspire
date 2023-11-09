using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private static Dictionary<string, Dictionary<string, int>> inventoryItems = new Dictionary<string, Dictionary<string, int>>();
    public static List<string> teamMembers = new List<string>();
    private static bool FirstTime = true;

    void Start()
    {
        if(FirstTime){
            AddItem("Potion", 5);
            AddItem("Gold", 900);
            AddItem("KWeap");
            AddItem("KArmor");
            AddItem("FrozenHearts", 0, 0);
            teamMembers.Add("Knight");
            FirstTime = false;
        }
    }

    // Add an item to the inventory
    public void AddItem(string itemName, int quantity = 1, int level = 1)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            inventoryItems[itemName]["quantity"] += quantity;
            inventoryItems[itemName]["level"] = level;
        }
        else
        {
            Dictionary<string, int> newItemData = new Dictionary<string, int>
            {
                { "quantity", quantity },
                { "level", level }
            };
            inventoryItems[itemName] = newItemData;
        }

        Debug.Log("Added " + quantity + " " + itemName + "(s) to the inventory at level " + level + ".");
    }

    // Remove an item from the inventory
    public void RemoveItem(string itemName, int quantity = 1)
    {
        if (inventoryItems.ContainsKey(itemName))
        {
            inventoryItems[itemName]["quantity"] -= quantity;

            if (inventoryItems[itemName]["quantity"] <= 0)
            {
                inventoryItems.Remove(itemName);
            }

            Debug.Log("Removed " + quantity + " " + itemName + "(s) from the inventory.");
        }
        else
        {
            Debug.LogWarning("Inventory does not contain " + itemName);
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(string itemName)
    {
        return inventoryItems.ContainsKey(itemName);
    }

    // Get the quantity of a specific item in the inventory
    public int GetItemQuantity(string itemName)
    {
        return inventoryItems.ContainsKey(itemName) ? inventoryItems[itemName]["quantity"] : 0;
    }

    // Get the level of a specific item in the inventory
    public int GetItemLevel(string itemName)
    {
        return inventoryItems.ContainsKey(itemName) ? inventoryItems[itemName]["level"] : 0;
    }

    // Check if a person is in the team
    public bool IsPersonInTeam(string personName)
    {
        return teamMembers.Contains(personName);
    }

    // Get the list of team members
    public List<string> GetTeamMembers()
    {
        return teamMembers;
    }

    // Print all items in the inventory (for debugging purposes)
    public void PrintInventory()
    {
        foreach (var item in inventoryItems)
        {
            Debug.Log(item.Key + ": Quantity - " + item.Value["quantity"] + ", Level - " + item.Value["level"]);
        }
    }
}
