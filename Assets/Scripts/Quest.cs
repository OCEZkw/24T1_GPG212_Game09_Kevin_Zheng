using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum QuestName
{
    None,
    FindTimeCapsules,
    DeliverTimeCapsules,
    ObtainTimeTicket
}
[System.Serializable]
public class Quest
{
    public QuestName questName;
    public string questDescription;
    public int requiredItemCount;
    public bool isCompleted;

    public Quest(QuestName name, string description, int itemCount)
    {
        questName = name;
        questDescription = description;
        requiredItemCount = itemCount;
        isCompleted = false;
    }
}
