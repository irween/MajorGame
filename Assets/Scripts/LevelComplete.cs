using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private GameObject gameManager;

    public int maxWave;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    public void LoadNextLevel()
    {
        if (gameManager.GetComponent<GameManager>().currentWave == maxWave)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
