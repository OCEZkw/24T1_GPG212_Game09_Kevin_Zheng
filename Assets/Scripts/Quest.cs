using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest
{
    public string questName;
    public string questDescription;
    public int requiredItemCount;
    public bool isCompleted;

    public Quest(string name, string description, int itemCount)
    {
        questName = name;
        questDescription = description;
        requiredItemCount = itemCount;
        isCompleted = false;
    }
}