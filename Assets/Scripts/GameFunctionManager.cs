using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunctionManager : MonoBehaviour
{
    public GameObject settingPanel;

    public void ShowObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void HideObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
