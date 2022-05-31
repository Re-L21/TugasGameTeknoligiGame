using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject about;

    private void Start()
    {
        about.SetActive(false);
    }

    public void About()
    {
        about.SetActive(true);
    }

    public void CloseAbout()
    {
        about.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
