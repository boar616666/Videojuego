using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MovTerminado"); // nombre exacto de la escena
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
