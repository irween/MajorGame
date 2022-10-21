using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // list of score gameobjects (one for game over screen and other for ui)
    public List<TextMeshProUGUI> scoreGameObjects;

    // sets gamemanager and score
    private GameManager gameManager;
    private int score; // current score that the player has

    // Start is called before the first frame update
    void Start()
    {
        // find gamemanager
        gameManager = FindObjectOfType<GameManager>();
    }
    
    // called whenever the score updates
    // updates the score text
    public void UpdateScore()
    {
        // sets the score variable to the gamemanager score
        score = gameManager.score;

        // runs for each score game object in list
        for (int i = 0; i < scoreGameObjects.Count; i++)
        {
            // sets the corresponding score game object to the score
            scoreGameObjects[i].text = score.ToString();
        }
    }
}
