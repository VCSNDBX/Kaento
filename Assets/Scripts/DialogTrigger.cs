using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().QuestDialog(dialog);
    }

    public void TriggerDialog2()
    {
        FindObjectOfType<DialogManager>().SignsDialog(dialog);
    }

    public void TriggerDialog3()
    {
        FindObjectOfType<DialogManager>().BookDialog(dialog);
    }
}
