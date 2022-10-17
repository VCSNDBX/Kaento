using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestQuestionManager : MonoBehaviour
{
    public TMP_Text questiontext;
    public List<Transform> allquestions;
    public string operation;
    public int questionidtoshow;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child != null && child.tag == "Question")
            {
                allquestions.Add(child);
            }
        }
        ShowQuestion();
    }

    public void ShowQuestion()
    {
        if (allquestions.Count > 0)
        {
            questionidtoshow = Random.Range(0, allquestions.Count);
            allquestions[questionidtoshow].gameObject.SetActive(true);
        }
    }

    public void RemoveQuestion(GameObject question)
    {
        allquestions.Remove(question.transform);
    }
}
