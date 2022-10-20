using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject levelComplete;

    void Start()
    {
        levelComplete.SetActive(false);
        gameOverUI.SetActive(false);
    }
    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
    }

    public void KillPlayer()
    {
        gameOverUI.SetActive(true);
    }
}
