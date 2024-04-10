using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPC : MonoBehaviour
{
    public float interactionRange = 2f; // The range within which the player can interact with the NPC
    public GameObject questMenuPanel; // Reference to the quest menu panel
    public TextMeshProUGUI interactionText; // Reference to the TextMeshPro text component
    public Quest quest; // The quest assigned to this NPC

    private Transform player;
    private bool inRange = false;
    private QuestManager questManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactionText.gameObject.SetActive(false); // Hide the text by default
        questManager = QuestManager.instance;
    }

    private void Update()
    {
        // Check if the player is in range
        if (Vector2.Distance(transform.position, player.position) <= interactionRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        // Show the interaction text when the player is in range
        interactionText.gameObject.SetActive(inRange && questManager.CanInteractWithNPC());

        // Open the quest menu panel when 'F' is pressed and the player is in range
        if (inRange && Input.GetKeyDown(KeyCode.F) && !questManager.IsOnMission())
        {
            // Update the quest menu panel text with the quest assigned to this NPC
            QuestManager.instance.questNameText.text = quest.questName;
            QuestManager.instance.questDescriptionText.text = quest.questDescription;
            questMenuPanel.SetActive(true);
        }
    }
}
