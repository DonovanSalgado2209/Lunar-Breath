using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPause;

    // Start is called before the first frame update
    public void BotonIniciar()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void BotonSalir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
