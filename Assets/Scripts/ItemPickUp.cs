using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddItem(item);
            if (item.name == "Time Capsule")
            {
                // Check if the player has collected 3 time capsules
                if (Inventory.instance.GetItemCount("Time Capsule") >= 3)
                {
                    QuestManager.instance.CheckQuestCompletion();
                }
            }
            Destroy(gameObject);
        }
    }
}
