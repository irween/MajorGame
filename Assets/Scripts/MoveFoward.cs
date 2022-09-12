using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    // public variables
    public float speed = 40f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // moves the gameobject by a designated amount every frame
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
