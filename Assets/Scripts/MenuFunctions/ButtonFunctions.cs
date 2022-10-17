using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("InsideHome");
    }

    public void TutorialGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ShowObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void HideObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
