using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public InputMaster pauseAction;


    private void Awake()
    {
        pauseAction = new InputMaster();
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    private void Start()
    {
        isPaused = false;
        pauseAction.UI.Pause.performed += _ => DeterminePause();
    }

    void DeterminePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        //AudioListener.pause = true;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        //AudioListener.pause = false;
        isPaused = false;
    }
  

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
