using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionScriptGenerator : MonoBehaviour
{
    public GameObject[] choices;
    public int rightanswer;
    public TMP_Text timertext;
    public bool iscorrectlyanswered;
    public GameObject[] questions;
    public GameObject GameManager, gquestion;
    private GameObject player;
    QuestQuestionManager qqm;
    public List<int> randomnumbers = new List<int>();
    int rand;

    // New Question Genarator
    string generatequestion;
    public int ranswer, rranswer;
    public TMP_Text questiontext;
    public int WrongAnswer;
    int minVal, maxVal;

    void Start()
    {
        qqm = GetComponentInParent<QuestQuestionManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        minVal = 1;
        maxVal = 4;
        randomnumbers = new List<int>(new int[maxVal]);
        for (int j = 1; j < maxVal; j++)
        {
            rand = Random.Range(minVal, maxVal);
            while (randomnumbers.Contains(rand))
            {
                rand = Random.Range(minVal, maxVal);
            }
            randomnumbers[j] = rand;
        }

        iscorrectlyanswered = false;
        WrongAnswer = 0;
        GenerateQuestion();
    }

    public void GenerateQuestion()
    {        
        //questiontext.text = generatequestion;
        rranswer = Random.Range(0, 3);
        switch (rranswer)
        {
            case 0:
                choices[0].GetComponent<ChoicesScript>().choicetext.text = ranswer.ToString();
                FixedRandomChoice(choices[0], choices[1], choices[2]);
                break;
            case 1:
                choices[1].GetComponent<ChoicesScript>().choicetext.text = ranswer.ToString();
                FixedRandomChoice(choices[1], choices[0], choices[2]);
                break;
            case 2:
                choices[2].GetComponent<ChoicesScript>().choicetext.text = ranswer.ToString();
                FixedRandomChoice(choices[2], choices[1], choices[0]);
                break;
        }
        foreach (GameObject choice in choices)
        {
            choice.GetComponent<ChoicesScript>().CheckChoice();
        }

    }

    void FixedRandomChoice(GameObject rranswer, GameObject choice, GameObject choice1)
    {
        Randomize(choice);
        foreach (int n in randomnumbers)
        {
            if (choice1.GetComponent<ChoicesScript>().choicetext.text == "Answer")
            {
                if (choice.GetComponent<ChoicesScript>().choicetext.text != n.ToString() && rranswer.GetComponent<ChoicesScript>().choicetext.text != n.ToString())
                {
                    choice1.GetComponent<ChoicesScript>().choicetext.text = n.ToString();
                }
            }
        }

    }

    void Randomize(GameObject choice)
    {
        choice.GetComponent<ChoicesScript>().choicetext.text = Random.Range(1, 4).ToString();
        if (choice.GetComponent<ChoicesScript>().choicetext.text == ranswer.ToString())
        {
            Randomize(choice);
        }
    }

    public void DecideTheResult()
    {
        GameManager.GetComponent<QuestManager>().AddScore(1);
    }

    public void WrongResult()
    {
        string[] sad = new string[] { "Let's try that again!", "So close! Try again!", "You can do it, try another question!", "Nice try! You can do it!", "It's okay! Try again!", "Let's go for gold, try again!" };
        System.Random random = new System.Random();
        int useSad = random.Next(sad.Length);
        string pickSad = sad[useSad];
        //resultScript.ShowResult(pickSad);
        GameManager.GetComponent<QuestManager>().WrongAnswer(0);
        //FindObjectOfType<WrongAnswerSound>().Play(pickSad);
    }

    // Update is called once per frame
    void Update()
    {
        if (iscorrectlyanswered == false)
        {

        }
        else
        {

        }
    }
}