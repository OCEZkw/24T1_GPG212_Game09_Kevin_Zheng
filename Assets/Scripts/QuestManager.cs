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
    public GameObject congratulatoryPanel; 
    private bool isOnMission = false;
    public bool canInteractWithNPC = true;
    public Inventory inventory;
    public Timer timer;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        timer = FindObjectOfType<Timer>();

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
        isOnMission = false;
        Debug.Log("Reward Given");
        congratulatoryPanel.SetActive(false);
        Inventory.instance.RemoveItem(new Item("TimeCapsule", "Time Capsule", 3));

        // Add 2 minutes to the timer
        if (timer != null)
        {
            timer.AddTime(120);
        }
        else
        {
            Debug.LogError("Timer script not found.");
        }
        // Generate a random number between 0 and 99
        int randomNumber = Random.Range(0, 100);

        // If the random number is less than 10 (10% chance), give the player a "Time Ticket" item
        if (randomNumber < 10)
        {
            Item timeTicket = new Item("TimeTicket", "Time Ticket", 1);
            inventory.AddItem(timeTicket);
        }
    }

    public void CompleteQuest2()
    {
        congratulatoryPanel.SetActive(false);
        isOnMission = false;
        // Add 2 minutes to the timer
        if (timer != null)
        {
            timer.AddTime(120);
        }
        else
        {
            Debug.LogError("Timer script not found.");
        }

        // Generate a random number between 0 and 99
        int randomNumber = Random.Range(0, 100);

        // If the random number is less than 10 (10% chance), give the player a "Time Ticket" item
        if (randomNumber < 10)
        {
            Item timeTicket = new Item("TimeTicket", "Time Ticket", 1);
            inventory.AddItem(timeTicket);
        }
    }

    public void OnQuestAccepted()
    {
        questMenuPanel.SetActive(false); // Hide the quest menu panel
        AcceptQuest(currentQuest);
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

    public Quest CurrentQuest
    {
        get { return currentQuest; }
    }

}