using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed;

    private float horizontalInput;
    private float verticalInput;

    public float lookHorizontalInput;
    public float lookVerticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // gets the horizontal input (A, D) with a value (-1, 1)
        verticalInput = Input.GetAxis("Vertical"); // gets the horizontal input (W, S) with a value (-1, 1)

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        lookHorizontalInput = Input.GetAxis("LookHorizontal");
        lookVerticalInput = Input.GetAxis("LookVertical");
        Vector3 lookDirection = new Vector3(lookHorizontalInput, 0, lookVerticalInput);

        if (lookDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
