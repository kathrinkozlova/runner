using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public Text text;
    public bool isOn = true;


    // Use this for initialization
    void Start()
    {
        
        Sound();
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene("Runner");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sound()
    {

        if (isOn)
        {
           text.text = "Sound: ON";
           AudioListener.pause = false;
           isOn = false;

        }
        else
        {
            text.text = "Sound: OFF";
           AudioListener.pause = true;
           isOn = true;

        }

    }

    public void Exit()
    {
        Application.Quit();
    }
}
