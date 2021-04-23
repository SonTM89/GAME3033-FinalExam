using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void OnPlayButtonPressed()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("GameplayScene");
    }


    public void OnQuitButtonPressed()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void OnMainMenuButtonpressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
