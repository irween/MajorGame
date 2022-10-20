using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private GameObject gameManager;
    private int score;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        scoreText = GameObject.Find("ScoreNumber").GetComponent<Text>();
    }
    
    public void UpdateScore()
    {
        score = gameManager.GetComponent<GameManager>().score;
        scoreText.text = score.ToString();
    }
}
