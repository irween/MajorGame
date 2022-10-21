using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private GameManager gameManager;

    public int bossWave;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void LoadNextLevel()
    {
        if (gameManager.currentWave == bossWave)
        {
            SceneManager.LoadScene("BossLevel");
        }
    }
}
