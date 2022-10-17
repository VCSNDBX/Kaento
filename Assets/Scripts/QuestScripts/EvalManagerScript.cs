using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EvalManagerScript : MonoBehaviour
{
    public GameObject DialogManager;
    public BookScript bs;
    public QuestionScripts qs;
    public TMP_Text scoreboard; 
    //Senses
    public float scorrectans;
    public float ss;
    public float stage1done;
    //Butterfly
    public float bcorrectans;
    public float bb;
    public float stage2done;
    //Planets
    public float pcorrectans;
    public float pp;
    public float stage3done;    public string score;

    private void Start()
    {
        scorrectans = PlayerPrefs.GetFloat("sdone");
        bcorrectans = PlayerPrefs.GetFloat("bdone");
        pcorrectans = PlayerPrefs.GetFloat("pdone");
        ss = PlayerPrefs.GetFloat("ss");
        bb = PlayerPrefs.GetFloat("bb");
        pp = PlayerPrefs.GetFloat("pp");
        stage1done = PlayerPrefs.GetFloat("stage1");
        stage2done = PlayerPrefs.GetFloat("stage2");
        stage3done = PlayerPrefs.GetFloat("stage3");
        if (bs.sensebookisread == true)
        {
            ss = PlayerPrefs.GetFloat("ss");

        } else if (bs.butterflybookisread == true)
        {
            bb = PlayerPrefs.GetFloat("bb");
        } else if (bs.planetsbookisread == true)
        {
            pp = PlayerPrefs.GetFloat("pp");
        }

        if (qs.teacher == "senses")
        {
            scoreboard.text = scorrectans + "/3";
        } else if (qs.teacher == "butterfly")
        {
            scoreboard.text = bcorrectans + "/3";
        } else if (qs.teacher == "planets")
        {
            scoreboard.text = pcorrectans + "/3";
        }
    }

    private void Update()
    {
        stage1done = PlayerPrefs.GetFloat("stage1");
        stage2done = PlayerPrefs.GetFloat("stage2");
        stage3done = PlayerPrefs.GetFloat("stage3");
        scorrectans = PlayerPrefs.GetFloat("sdone");
        bcorrectans = PlayerPrefs.GetFloat("bdone");
        pcorrectans = PlayerPrefs.GetFloat("pdone");
        ss = PlayerPrefs.GetFloat("ss");
        bb = PlayerPrefs.GetFloat("bb");
        pp = PlayerPrefs.GetFloat("pp");
        if (bs.sensebookisread == true)
        {
            ss = PlayerPrefs.GetFloat("ss");

        }
        else if (bs.butterflybookisread == true)
        {
            bb = PlayerPrefs.GetFloat("bb");
        }
        else if (bs.planetsbookisread == true)
        {
            pp = PlayerPrefs.GetFloat("pp");
        }

        if (qs.teacher == "senses")
        {
            scoreboard.text = scorrectans + "/3";
        }
        else if (qs.teacher == "butterfly")
        {
            scoreboard.text = bcorrectans + "/3";
        }
        else if (qs.teacher == "planets")
        {
            scoreboard.text = pcorrectans + "/3";
        }
    }
}
