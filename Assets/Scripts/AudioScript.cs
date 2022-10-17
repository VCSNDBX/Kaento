using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public Sounds[] sound;
    public float volume;
    public GameObject audioSource;
    public Button soundBtn;
    public Text soundTxt;
    bool soundToggle = true;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void OnVolume()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            //audioSource.SetActive(true);
            //audioSource.mute = true;
            soundTxt.text = "ON";
            soundToggle = true;
            AudioListener.volume = 1.0f;
        }
        else
        {
            //audioSource.mute = false;
            soundTxt.text = "OFF";
            soundToggle = false;
            AudioListener.volume = 0.0f;
        }
    }
}
