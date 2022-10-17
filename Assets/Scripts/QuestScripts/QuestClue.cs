using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestClue : MonoBehaviour
{
    public GameObject questClue;

    public void Enable()
    {
        questClue.SetActive(true);
    }

    public void Disable()
    {
        questClue.SetActive(false);
    }
}
