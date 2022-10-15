using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void OnSliderChanged(float value)
    {
        gameManager.GetComponent<GameManager>().difficulty = value;
    }
}
