using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // set the speed and rotation speed
    public float speed = 10f; // how fast the player moves
    public float rotationSpeed; // how fast the player rotates

    // sets the horizontal and vertical look inputs
    private float lookHorizontalInput;
    private float lookVerticalInput;

    // sets the horizontal and vertical movement inputs
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    { 
        horizontalInput = Input.GetAxis("Horizontal"); // gets the horizontal input (A, D) with a value (-1, 1)
        verticalInput = Input.GetAxis("Vertical"); // gets the horizontal input (W, S) with a value (-1, 1)

        // creates a new Vector3 and changes the x and z to the horizontal and vertical inputs
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        // moves the player by the movement direction Vector3 and multiplies by speed and time.deltatime
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        lookHorizontalInput = Input.GetAxis("LookHorizontal"); // gets the look horizontal input (left and right arrows) with a value (-1, 1)
        lookVerticalInput = Input.GetAxis("LookVertical"); // gets the look vertical input (up and down arrows) with a value (1, -1)

        // creates a new Vector3 and changes the x and z to the horizontal and vertical look inputs
        Vector3 lookDirection = new Vector3(lookHorizontalInput, 0, lookVerticalInput);

        // checking if look direction has a value and does not equal (0, 0, 0)
        if (lookDirection != Vector3.zero)
        {
            // creating a Quaternion that sets the rotation based on the Vector3
            Quaternion toRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            // changes the rotation based on the Quaternion and rotation speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
