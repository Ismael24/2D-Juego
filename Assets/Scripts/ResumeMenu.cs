using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown("escape")) 
        {
            PauseUnpause();
        }
    }

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

    public void MainMenu() 
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;

    }

    
}
