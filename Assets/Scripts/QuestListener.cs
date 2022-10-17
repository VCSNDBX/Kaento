using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestListener : MonoBehaviour
{
    public QuestSignal quest;
    public UnityEvent questEvent;

    public void OnQuestRaise()
    {
        questEvent.Invoke();
    }

    private void OnEnable()
    {
        quest.RegisterQListener(this);
    }

    private void OnDisable()
    {
        quest.DeRegisterQListener(this);
    }
}
