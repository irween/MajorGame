using UnityEngine;

public class end_trig : MonoBehaviour
{
    public GameManager gameManager;

    private int enemyCount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                gameManager.CompleteLevel();
            }
        }
    }
}
