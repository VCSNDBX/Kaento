using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    public QuestSignal contextOn;
    public QuestSignal contextOff;
    public GameObject dialogBox, bookImage;
    public DialogTrigger dialogTrigger;
    public Button interactBtn;
    public bool playerInRange;
    public bool isreadbook, isreadbook2, isreadbook3, isbookreview, sensebookisread, butterflybookisread, planetsbookisread;

    private void Start()
    {
    }

    private void Update()
    {
        /*if (isbookreview)
        {
            contextOn.Raise();
        }
        else
        {
            contextOff.Raise();
        }*/
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
