using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject optionsPause;

    public void OptionsMenu()
    {
        Time.timeScale = 0;
        optionsPause.SetActive(true);
    }
    public void Return()
    {
        Time.timeScale = 1;
        optionsPause.SetActive(false);
    }

    public void AnotherOptions()
    {

    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}