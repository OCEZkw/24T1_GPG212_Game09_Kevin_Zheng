using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC3 : MonoBehaviour
{
    public float interactionRange = 1f; // The range within which the player can interact with the NPC
    public TextMeshProUGUI interactionText; // Reference to the TextMeshPro text component
    public Quest quest; // The quest assigned to this NPC

    private Transform player;
    private bool inRange = false;
    private QuestManager questManager;
    public GameObject congratulatoryPanel;

    public string npcName;
    private TextMeshProUGUI nameText;
    private Canvas canvas;

    private void Awake()
    {
        questManager = QuestManager.instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactionText.gameObject.SetActive(false); // Hide the text by default
    }

    private void Start()
    {
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

        // Show the interaction text when the player is in range and on the deliver mission
        interactionText.gameObject.SetActive(inRange && !questManager.CanInteractWithNPC() && questManager.IsOnMission());


        if (inRange && Input.GetKeyDown(KeyCode.F) && questManager.IsOnMission() && !questManager.CanInteractWithNPC())
        {
            congratulatoryPanel.SetActive(true);
        }

        if (congratulatoryPanel.activeSelf)
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
