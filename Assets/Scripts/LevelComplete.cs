using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private GameObject gameManager;

    public int bossWave;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    public void LoadNextLevel()
    {
        if (gameManager.GetComponent<GameManager>().currentWave == bossWave)
        {
            SceneManager.LoadScene("BossLevel");
        }
    }
}
