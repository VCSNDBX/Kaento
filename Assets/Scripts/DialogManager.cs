using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Queue<string> sentences;
    public GameObject[] choices;

    public Text nameText;
    public Text dialogText;
    public Animator animator;
    public QuestionScripts qs;
    public BookScript bs;
    public GameObject AnsBox, NextBox;
    public string[] randomanswer;
    public int rand;

    string thisbook;
    public string ranswer;
    public int rranswer;
    public string pickRand;
    public bool iscorrectlyanswered;
    public EvalManagerScript ems;

    private void Start()
    {
        sentences = new Queue<string>();

        string teacher = qs.teacher;
        switch (teacher)
        {
            case "senses":
                qs.sense = true;
                qs.questActive = true;
                thisbook = "The 5 Senses";

                sentences.Clear();
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                DisplayNextDialog();
                break;
            case "butterfly":
                qs.butterfly = true;
                qs.questActive2 = true;
                thisbook = "The Stages of Butterfies";

                sentences.Clear();
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                DisplayNextDialog();
                break;
            case "planets":
                qs.planets = true;
                qs.questActive3 = true;
                thisbook = "The Solar System";

                sentences.Clear();
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                DisplayNextDialog();
                break;
        }
    }

    public void QuestDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();

        if (qs.questActive == true)
        {
            if (ems.ss == 0)
            {
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                bs.isreadbook = true;
                DisplayNextDialog();
            }

            if (ems.ss == 1)
            {
                if (qs.sense == true)
                {
                    if (ems.scorrectans >= 3)
                    {
                        sentences.Enqueue("You did great! Please go to your next class.");
                        DisplayNextDialog();
                    }
                    else
                    {
                        int useQuestion = Random.Range(0, 3);
                        string pickQuestion = dialog.questions[useQuestion];
                        sentences.Enqueue(pickQuestion);

                        if (pickQuestion == dialog.questions[0])
                        {
                            randomanswer = new string[] { "Eyes", "Hands", "Nose" };
                            ranswer = "Tounge";
                        }
                        if (pickQuestion == dialog.questions[1])
                        {
                            randomanswer = new string[] { "Hands", "Ears", "Tounge" };
                            ranswer = "Touch";
                        }
                        if (pickQuestion == dialog.questions[2])
                        {
                            randomanswer = new string[] { "Touch", "Ears", "Hands" };
                            ranswer = "Nose";
                        }
                        DisplayNextQuestion();
                    }
                }
            }
        }
        else if (qs.questActive2 == true)
        {
            if (qs.teacher == "butterfly" && ems.stage1done == 0)
            {
                sentences.Enqueue("Sorry, but you need to finish first the other exam before you can take mine.");
                bs.isreadbook2 = false;
                DisplayNextDialog();
            }

            if (ems.bb == 0)
            {
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                bs.isreadbook2 = true;
                DisplayNextDialog();
            }

            if (ems.bb == 1)
            {
                if (qs.butterfly == true)
                {
                    if (ems.bcorrectans >= 3)
                    {
                        sentences.Enqueue("You did great! Please go to your next class.");
                        DisplayNextDialog();
                    }
                    else
                    {
                        int useQuestion = Random.Range(0, 3);
                        string pickQuestion = dialog.questions[useQuestion];
                        sentences.Enqueue(pickQuestion);

                        if (pickQuestion == dialog.questions[0])
                        {
                            randomanswer = new string[] { "1st", "2nd", "4th", "5th" };
                            ranswer = "3rd";
                        }
                        else if (pickQuestion == dialog.questions[1])
                        {
                            randomanswer = new string[] { "Transformation", "Hibernation" };
                            ranswer = "Metamorphosis";
                        }
                        else if (pickQuestion == dialog.questions[2])
                        {
                            randomanswer = new string[] { "1st", "3rd", "4th", "5th" };
                            ranswer = "2nd";
                        }
                        DisplayNextQuestion();
                    }
                }
            }
        }
        else if (qs.questActive3 == true)
        {

            if (qs.teacher == "planets" && ems.stage2done == 0)
            {
                sentences.Enqueue("Sorry, but you need to finish first the other exam before you can take mine.");
                bs.isreadbook3 = false;
                DisplayNextDialog();
            }

            if (ems.pp == 0)
            {
                sentences.Enqueue("Please read the book about " + thisbook + ".");
                bs.isreadbook3 = true;
                DisplayNextDialog();
            }

            if (ems.pp == 1)
            {
                if (qs.planets == true)
                {
                    if (ems.pcorrectans >= 3)
                    {
                        sentences.Enqueue("Good job! You finish all the exam. Go home and take some rest.");
                        DisplayNextDialog();
                    }
                    else
                    {
                        int useQuestion = Random.Range(0, 3);
                        string pickQuestion = dialog.questions[useQuestion];
                        sentences.Enqueue(pickQuestion);

                        if (pickQuestion == dialog.questions[0])
                        {
                            randomanswer = new string[] { "Mars", "Pluto", "Earth", "Venus", "Sun", "Uranus", "Jupiter", "Saturn" };
                            ranswer = "Mercury";
                        }
                        else if (pickQuestion == dialog.questions[1])
                        {
                            randomanswer = new string[] { "Venus", "Earth", "Mars", "Pluto", "Sun", "Uranus", "Jupiter", "Mercury" };
                            ranswer = "Saturn";
                        }
                        else if (pickQuestion == dialog.questions[2])
                        {
                            randomanswer = new string[] { "Venus", "Saturn", "Mars", "Pluto", "Sun", "Uranus", "Jupiter", "Mercury" };
                            ranswer = "Earth";
                        }
                        DisplayNextQuestion();
                    }
                }
            }
        }
    }

    public void DecideTheResult()
    {
        if (qs.teacher == "senses")
        {
            if (iscorrectlyanswered == true)
            {
                sentences.Clear();
                if (ems.scorrectans >= 2)
                {
                    sentences.Enqueue("Great! You completed my exam. You can now proceed to the next room.");
                    iscorrectlyanswered = false;
                    PlayerPrefs.SetFloat("stage1", 1);
                }
                else
                {
                    sentences.Enqueue("Nice Job! You did read the book.");
                    iscorrectlyanswered = false;
                }
                PlayerPrefs.SetFloat("sdone", PlayerPrefs.GetFloat("sdone") + 1);
            }
            else
            {
                sentences.Clear();
                sentences.Enqueue("Are you sure you've read the book about " + thisbook + "?");
            }
        }
        else if (qs.teacher == "butterfly")
        {
            if (iscorrectlyanswered == true)
            {
                sentences.Clear();
                if (ems.bcorrectans >= 2)
                { 
                    sentences.Enqueue("Great! You completed my exam. You can now proceed to the next room.");
                    iscorrectlyanswered = false;
                    PlayerPrefs.SetFloat("stage2", 1);
                }
                else
                {
                    sentences.Enqueue("Nice Job! You did read the book.");
                    iscorrectlyanswered = false;
                }
                PlayerPrefs.SetFloat("bdone", PlayerPrefs.GetFloat("bdone") + 1);
            }
            else
            {
                sentences.Clear();
                sentences.Enqueue("Are you sure you've read the book about " + thisbook + "?");
            }
        }
        else if (qs.teacher == "planets")
        {
            if (iscorrectlyanswered == true)
            {
                sentences.Clear();
                if (ems.pcorrectans >= 2)
                {
                    sentences.Enqueue("Great! You completed my exam. You can now proceed to the next room.");
                    iscorrectlyanswered = false;
                    PlayerPrefs.SetFloat("stage3", 1);
                }
                else
                {
                    sentences.Enqueue("Nice Job! You did read the book.");
                    iscorrectlyanswered = false;
                }
                PlayerPrefs.SetFloat("pdone", PlayerPrefs.GetFloat("pdone") + 1);
            }
            else
            {
                sentences.Clear();
                sentences.Enqueue("Are you sure you've read the book about " + thisbook + "?");
            }
        }
        
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
    }

    public void BookDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        sentences.Clear();

        if (bs.isreadbook == true)
        {
            if (qs.sense == true)
            {
                bs.bookImage.SetActive(true);
                nameText.text = "The 5 Senses";
                string[] sensing = { "Sense of sight helps you to see all things. Including colors and beautiful pictures.",
                "Sense of touch helps you to sense if the thing is rough, smooth or soft.",
                "Sense of taste helps you to determine thae taste of your food whether sweet, spicy or sour.",
                "Sense of hearing helps you to hear things such as music, news, and lessons.",
                "Sense of smells helps you to determine the aroma of things."};

                foreach (string sentence in sensing)
                {
                    sentences.Enqueue(sentence);
                }
                bs.sensebookisread = true;
                PlayerPrefs.SetFloat("ss", 1);
            }
        }
        else if (bs.isreadbook2 == true)
        {
            if (qs.butterfly == true)
            {
                bs.bookImage.SetActive(true);
                nameText.text = "The Butterfly Effect";
                string[] butt = { "Butterfly has 5 stages of transformation.",
                "First is egg, second is larvae,",
                "Third is pupa, fourth is young adult,",
                "And last is the adult."};

                foreach (string sentence in butt)
                {
                    sentences.Enqueue(sentence);
                }
                bs.butterflybookisread = true;
                PlayerPrefs.SetFloat("bb", 1);
            }
        }
        else if (bs.isreadbook3 == true)
        {
            if (qs.planets == true)
            {
                bs.bookImage.SetActive(true);
                nameText.text = "The Solar System";
                string[] solar = { "There are 8 planets in our solar system.",
                "Mercury is the nearest planet to the sun.",
                "Earth is the only habitable planet in the solar system.",
                "Saturn is surrounded by dust particles that looks like a ring."};

                foreach (string sentence in solar)
                {
                    sentences.Enqueue(sentence);
                }
                bs.planetsbookisread = true;
                PlayerPrefs.SetFloat("pp", 1);
            }
        }
        else
        {
            foreach (string sentence in dialog.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextDialog();
        }
    }

    public void DisplayNextQuestion()
    {
        AnsBox.SetActive(true);
        NextBox.SetActive(false);

        System.Random randomans = new System.Random();
        rand = randomans.Next(randomanswer.Length);
        pickRand = randomanswer[rand];

        rranswer = Random.Range(0, 3);
        switch (rranswer)
        {
            case 0:
                choices[0].GetComponent<ChoicesScript>().choicetext.text = ranswer;
                FixedRandomChoice(choices[0], choices[1], choices[2]);
                break;
            case 1:
                choices[1].GetComponent<ChoicesScript>().choicetext.text = ranswer;
                FixedRandomChoice(choices[1], choices[0], choices[2]);
                break;
            case 2:
                choices[2].GetComponent<ChoicesScript>().choicetext.text = ranswer;
                FixedRandomChoice(choices[2], choices[1], choices[0]);
                break;
        }

        foreach (GameObject choice in choices)
        {
            choice.GetComponent<ChoicesScript>().istherightanswer = false;
            choice.GetComponent<ChoicesScript>().CheckChoice();
        }

        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string question = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(question));
    }

    public void SignsDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextDialog();
    }

    public void DisplayNextDialog()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }

    }
    public void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        bs.bookImage.SetActive(false);
    }

    void FixedRandomChoice(GameObject rranswer, GameObject choice, GameObject choice1)
    {
        Randomize(choice);
        foreach (string s in randomanswer)
        {
            if (choice1.GetComponent<ChoicesScript>().choicetext.text == "answer")
            {
                if (choice.GetComponent<ChoicesScript>().choicetext.text != s && rranswer.GetComponent<ChoicesScript>().choicetext.text != s)
                {
                    choice1.GetComponent<ChoicesScript>().choicetext.text = s;
                }
            }
        }
    }

    void Randomize(GameObject choice)
    {
        choice.GetComponent<ChoicesScript>().choicetext.text = randomanswer[Random.Range(0, randomanswer.Length)];
        if (choice.GetComponent<ChoicesScript>().choicetext.text == ranswer)
        {
            Randomize(choice);
        }
    }
}
