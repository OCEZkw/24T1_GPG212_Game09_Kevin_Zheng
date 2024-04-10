using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestA : MonoBehaviour
{
    public Quest quest;

    private void Start()
    {
        quest = new Quest("Find Time Capsules", "Find 3 time capsules and bring them back to me.", 3);
    }

    public void GiveQuest()
    {
        QuestManager.instance.AcceptQuest(quest);
    }
}
