using UnityEngine;

public class end_trig : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.CompleteLevel();
        }
    }
}
