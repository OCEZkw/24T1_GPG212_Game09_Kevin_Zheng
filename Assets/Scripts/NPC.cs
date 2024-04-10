using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPC : MonoBehaviour
{
    public Quest quest;
    public GameObject questPanel;
    public GameObject interactionText;
    public float interactionRange = 1f;

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= interactionRange)
        {
            interactionText.SetActive(true);
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                QuestManager.instance.ShowQuestPanel(quest, questPanel);
            }
        }
    }
}

