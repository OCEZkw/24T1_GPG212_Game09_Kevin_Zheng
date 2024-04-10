using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public GameObject questPanel;
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        questPanel.SetActive(false);
    }

    public void ShowQuestPanel(Quest quest, GameObject panel)
    {
        questNameText.text = quest.questName;
        questDescriptionText.text = quest.description;
        panel.SetActive(true);
    }

    public void HideQuestPanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}