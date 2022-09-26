using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_trig : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
