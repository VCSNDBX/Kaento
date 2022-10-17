using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMax;
    public VectorValue cameraMin;

    public float FadeWait;
    public GameObject FadeInScreen;
    public GameObject FadeOutScreen;

    private void Awake()
    {
        if(FadeInScreen != null)
        {
            GameObject panel = Instantiate(FadeInScreen, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeController());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeController()
    {
        if (FadeOutScreen != null)
        {
            Instantiate(FadeOutScreen, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(FadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone){
            yield return null;
        }
    }

    public void ResetCameraBounds()
    {
        Debug.Log("Changed View");
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
