using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public float score;
    public QuestionScriptGenerator qqm;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(float points)
    {
        score += points;
        if (score > 9)
        {
            score = 9;

        }
    }

    public void WrongAnswer(float points)
    {
        score += points;
        if (score > 9)
        {
            score = 9;
        }
    }

    public void HideGameobject(GameObject go)
    {
        go.SetActive(false);
    }
    
    public void ShowQuestion(GameObject go)
    {
        go.SetActive(true);
    }
}
