using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // set gamemanager
    private GameManager gameManager;

    // called by playbutton
    // triggers the start of the game
    public void PlayGame()
    {
        gameManager = FindObjectOfType<GameManager>(); // finds gamemanager
        gameManager.StartGame(); // triggers gamemanager start game function
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads next scene
    }
    
    // called by quit button
    // quits game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
