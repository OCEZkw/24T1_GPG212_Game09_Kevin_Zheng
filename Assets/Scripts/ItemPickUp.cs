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
                Inventory.instance.CheckTimeCapsulesCollected();
            }
            Destroy(gameObject);
        }
    }
}
