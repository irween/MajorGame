using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // set gameover and level complete ui gameobjects
    public GameObject gameOverUI;
    public GameObject levelComplete;

    // set gamemanager variable
    private GameManager gameManager;

    void Start()
    {
        // find the gamemanager
        gameManager = FindObjectOfType<GameManager>();

        // set fullscreen ui to inactive (doesn't display)
        levelComplete.SetActive(false);
        gameOverUI.SetActive(false);
    }

    // called when the level is completed
    // shows the differing end level ui
    public void CompleteLevel()
    {
        // checks if the boss level boolean is set to true
        if (gameManager.bossLevel) // if true sets game over ui to true
        {
            gameOverUI.SetActive(true);
        }
        else // if false then sets level complete ui to true
        {
            levelComplete.SetActive(true);
        }
    }

    // called when the player dies
    // shows the game over ui
    public void KillPlayer()
    {
        // sets game over ui to true
        gameOverUI.SetActive(true);
    }

    // called when going to main menu
    // loads the main menu
    public void MainMenu()
    {
        // loads the menu scene
        SceneManager.LoadScene("Menu");
    }
}
