using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item
{
    public string id; // Unique identifier for the item
    public string name;
    public int count;

    public Item(string id, string name, int count)
    {
        this.id = id;
        this.name = name;
        this.count = count;
    }
}
