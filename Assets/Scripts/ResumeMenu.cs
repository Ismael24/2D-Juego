using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Script para la pantalla de pausa 
 * @author Ismael Paloma Narváez
 */
public class ResumeMenu : MonoBehaviour
{
    public static ResumeMenu instance;
    public GameObject pauseScreen;
    public bool isPaused;
    public string mainMenu;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //asignamos el pausa a la tecla escape
        if (Input.GetKeyDown("escape")) 
        {
            PauseUnpause();
        }
    }
    //función que controla el pause
    public void PauseUnpause() 
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else 
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }

    }
    //posiblidad de volver al menu inicial
    public void MainMenu() 
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;

    }

    
}
