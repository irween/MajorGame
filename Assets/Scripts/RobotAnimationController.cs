using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    private Animator animator;

    public int currentGun;
    public Transform[] guns;

    private bool isShooting = false;
    private bool pistol = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pistol"))
        {
            pistol = !pistol;
            changeGun(1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }

        else if (!Input.GetButtonDown("Fire1"))
        {
            isShooting = false;
        }

        if (!pistol)
        {
            currentGun = 0;
        }

        animator.SetBool("Running", Input.GetAxisRaw("Vertical") != 0);
        animator.SetBool("Running", Input.GetAxisRaw("Horizontal") != 0);
        animator.SetBool("Pistol", pistol);
        animator.SetBool("Shooting", isShooting);
    }

    public void changeGun(int gun)
    {
        currentGun = gun;
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == gun)
            {
                guns[i].gameObject.SetActive(true);
            }
            else
            {
                guns[i].gameObject.SetActive(false);
            }
        }
    }
}
