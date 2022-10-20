using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private GameObject gameManager;
    private int score;

    public List<TextMeshProUGUI> scoreGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    
    public void UpdateScore()
    {
        score = gameManager.GetComponent<GameManager>().score;

        for (int i = 0; i < scoreGameObjects.Count; i++)
        {
            scoreGameObjects[i].text = score.ToString();
        }
    }
}
