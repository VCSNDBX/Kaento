using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public Signal contextOn;
    public Signal contextOff;
    public GameObject dialogBox;
    public Button interactBtn;
    public DialogTrigger dialogTrigger;
    public bool playerInRange;

    private void Update()
    {
    }

    public void ButtonClicked()
    {
        if (playerInRange)
        {
            dialogTrigger.TriggerDialog2();
            dialogBox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactBtn.interactable = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            interactBtn.interactable = false;
            contextOff.Raise();
        }
    }
}
