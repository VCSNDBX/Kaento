using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScripts : MonoBehaviour
{
    public QuestSignal contextOn;
    public QuestSignal contextOff;
    public GameObject dialogBox;
    public DialogTrigger dialogTrigger;
    public Button interactBtn;
    public bool playerInRange;
    public BookScript bs;
    public bool questActive, planets, butterfly, sense, questActive2, questActive3;
    public string teacher;

    private void Start()
    {
        /*if (questActive == false)
        {
            contextOn.Raise();
        }
        else
        {
            contextOff.Raise();
        }*/
    }

    private void Update()
    {
        if (questActive == false)
        {
            contextOn.Raise();
        } else
        {
            contextOff.Raise();
        }

        if (bs.isbookreview)
        {
            contextOn.Raise();
        }
        else
        {
            contextOff.Raise();
        }
    }

    public void ButtonClickedQuest()
    {
        if (playerInRange)
        {
            dialogTrigger.TriggerDialog();
            dialogBox.SetActive(true);
        }
    }

    public void ButtonClickedBook()
    {
        if (playerInRange)
        {
            dialogTrigger.TriggerDialog3();
            dialogBox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactBtn.interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactBtn.interactable = false;
        }
    }
}
