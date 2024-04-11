using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static Inventory instance;

    void Awake()
    {

        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

    }

    public void AddItem(Item itemToAdd)
    {
        bool itemExists = false;
        foreach (Item item in items)
        {
            if (item.id == itemToAdd.id)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }
        Debug.Log(itemToAdd.count + " " + itemToAdd.name + " added to inventory. ");

        // Check if the player has collected 3 time capsules
        if (itemToAdd.id == "TimeCapsule" && itemToAdd.count >= 3)
        {
            QuestManager.instance.CompleteQuest();
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        foreach (var item in items)
        {
            if (item.name == itemToRemove.name)
            {
                item.count -= itemToRemove.count;
                if (item.count <= 0)
                {
                    items.Remove(itemToRemove);
                }
                break;
            }
        }
        Debug.Log(itemToRemove.count + " " + itemToRemove.name + " removed from inventory.");
    }

    public int GetItemCount(string itemName)
    {
        int count = 0;
        foreach (var item in items)
        {
            if (item.name == itemName)
            {
                count += item.count;
            }
        }
        return count;
    }

    public void CheckTimeCapsulesCollected()
    {
        int timeCapsulesCollected = GetItemCount("Time Capsule");
        if (timeCapsulesCollected >= 3)
        {
            Debug.Log("3 Collected");
            QuestManager.instance.canInteractWithNPC = true;
        }
    }
}