using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // player gameobject
    public GameObject player;

    // offset of the camera
    public Vector3 offset = new Vector3(0, 12, -15);

    // Update is called once per frame
    void LateUpdate()
    {
        // changes the camera position to the player position with an offset in the Y position
        transform.position = player.transform.position + offset;
    }
}
