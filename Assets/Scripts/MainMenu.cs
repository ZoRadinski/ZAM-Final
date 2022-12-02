using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsScreen;
    public string GamePlay;
    public GameObject play;
    public GameObject quit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(GamePlay);
    }
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        play.SetActive(false);
        quit.SetActive(false);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        play.SetActive(true);
        quit.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
