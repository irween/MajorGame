using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // set gamemanager variable
    private GameManager gameManager;

    void Start()
    {
        // find gamemanager
        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// called whenever the difficulty slider changes value
    /// 
    /// value refers to the difficulty 0 = easy 1 = hard
    /// </summary>
    /// <param name="value"></param>
    public void OnSliderChanged(float value)
    {
        // set the difficulty
        gameManager.GetComponent<GameManager>().difficulty = value;
    }
}
