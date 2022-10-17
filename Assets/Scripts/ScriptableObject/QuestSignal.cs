using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestSignal : ScriptableObject
{
    public List<QuestListener> qlisteners = new List<QuestListener>();

    public void Raise()
    {
        for (int i = qlisteners.Count - 1; i >= 0; i--)
        {
            qlisteners[i].OnQuestRaise();
        }
    }

    public void RegisterQListener(QuestListener qlistener)
    {
        qlisteners.Add(qlistener);
    }

    public void DeRegisterQListener(QuestListener qlistener)
    {
        qlisteners.Remove(qlistener);
    }
}
