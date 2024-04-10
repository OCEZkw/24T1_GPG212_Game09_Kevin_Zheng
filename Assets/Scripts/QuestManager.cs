using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public List<Quest> quests = new List<Quest>();
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;
    public Button acceptQuestButton;

    private Quest currentQuest;
    public GameObject questMenuPanel;
    private bool isOnMission = false;
    private bool canInteractWithNPC = true;
    public Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();

        // Check if the inventory was found
        if (inventory == null)
        {
            Debug.LogError("Inventory component not found in the scene.");
        }

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AcceptQuest(Quest quest)
    {
        currentQuest = quest;
        isOnMission = true;
        canInteractWithNPC = false; // Player cannot interact with NPC while on a mission
    }



    public void CompleteQuest()
    {
        currentQuest.isCompleted = true;
        isOnMission = false;
        canInteractWithNPC = true; // Player can interact with NPC after completing the quest
                                   // You can add rewards or other logic here for completing the quest
    }

    public void OnQuestAccepted()
    {
        questMenuPanel.SetActive(false); // Hide the quest menu panel
        AcceptQuest(currentQuest);
    }

    public void CheckQuestCompletion()
    {
        // Check if the current quest is to find 3 time capsules
        if (currentQuest.questName == "Find Time Capsules" && Inventory.instance.GetItemCount("Time Capsule") >= currentQuest.requiredItemCount)
        {
            CompleteQuest();
        }
    }

    // Add a method to allow other scripts to check if the player is on a mission
    public bool IsOnMission()
    {
        return isOnMission;
    }

    // Add a method to allow other scripts to check if the player can interact with the NPC
    public bool CanInteractWithNPC()
    {
        return canInteractWithNPC;
    }
}