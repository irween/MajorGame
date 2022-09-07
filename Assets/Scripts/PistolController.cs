using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{ 
    public GameObject projectilePrefab;

    private float timeToFire;

    public float rapidShotAmount;
    public float timeToFireInterval = 0.5f;
    public Vector3 offset = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;

        // detects when the player presses or holds the mouse button
        if (Input.GetButtonDown("Fire1") && timeToFire <= 0)
        {
            Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
            timeToFireInterval = 0.5f;
            timeToFire = timeToFireInterval;
        }
    }
}
