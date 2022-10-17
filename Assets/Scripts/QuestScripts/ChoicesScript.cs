using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesScript : MonoBehaviour
{
    public Text choicetext;
    public bool istherightanswer;
    public DialogManager dm;
    public Text textChoice1;
    public Text textChoice2;
    public Text textChoice3;

    public void CheckChoice()
    {
        //int.TryParse(choicetext.text, out GetComponentInParent<DialogManager>().rranswer);
        //choicetext.text = GetComponentInParent<DialogManager>().ranswer;
        if (choicetext.text == dm.ranswer)
        {
            istherightanswer = true;
        }
    }

    public void RightAnswerClicked()
    {
        if (istherightanswer == true)
        {
            dm.iscorrectlyanswered = true;
            dm.DecideTheResult();
            string sentence = dm.sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            dm.iscorrectlyanswered = false;
            dm.DecideTheResult();
            string sentence = dm.sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dm.dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dm.dialogText.text += letter;
            yield return null;
        }
        textChoice1.text = "answer";
        textChoice2.text = "answer";
        textChoice3.text = "answer";
        dm.NextBox.SetActive(true);
        dm.AnsBox.SetActive(false);
    }
}
