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
    public TextMeshProUGUI interactionText2;
    public Quest quest; // The quest assigned to this NPC

    private Transform player;
    private bool inRange = false;
    private QuestManager questManager;
    public GameObject congratulatoryPanel;


    public string npcName;
    private TextMeshProUGUI nameText;
    private Canvas canvas;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactionText.gameObject.SetActive(false); // Hide the text by default
        questManager = QuestManager.instance;


        // Create a world space canvas if it doesn't exist
        CreateCanvas();

        // Create a TextMeshPro component as a child of the canvas
        CreateText();

        // Find the TextMeshProUGUI component
        nameText = GetComponentInChildren<TextMeshProUGUI>();
        if (nameText != null)
        {
            // Set the text to the NPC's name
            nameText.text = npcName;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found in children.");
        }
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
        interactionText.gameObject.SetActive(inRange && questManager.CanInteractWithNPC() && !questManager.IsOnMission());
        interactionText2.gameObject.SetActive(inRange && questManager.CanInteractWithNPC() && questManager.IsOnMission());

        // Open the quest menu panel when 'F' is pressed and the player is in range
        if (inRange && Input.GetKeyDown(KeyCode.F) && !questManager.IsOnMission())
        {
            // Update the quest menu panel text with the quest assigned to this NPC
            QuestManager.instance.questNameText.text = quest.questName.ToString();
            QuestManager.instance.questDescriptionText.text = quest.questDescription;
            questMenuPanel.SetActive(true);
        }

        if (inRange && Input.GetKeyDown(KeyCode.F) && questManager.IsOnMission() && questManager.CanInteractWithNPC())
        {
            congratulatoryPanel.SetActive(true);
        }

        if (questMenuPanel.activeSelf)
        {
            interactionText.gameObject.SetActive(false);
        }

    }

    private void CreateCanvas()
    {
        canvas = gameObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.sortingOrder = 1; // Ensure canvas is rendered above other objects
    }

    private void CreateText()
    {
        GameObject textObject = new GameObject("NameText");
        textObject.transform.SetParent(canvas.transform);
        textObject.transform.localPosition = new Vector3(0, 0.5f, 0); // Position above NPC
        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
        textComponent.fontSize = 0.3f;
        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.text = npcName;
    }
}
