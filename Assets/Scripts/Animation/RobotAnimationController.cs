using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    private Animator animator;

    public int currentGun;
    public GameObject[] guns;

    public float lookHorizontalInput;
    public float lookVerticalInput;
    
    public float timeToFireInterval;

    private float timeToFire;

    private bool isShooting = false;
    private bool pistol = false;
    private bool machineGun = false;
    private bool shotgun = false;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lookHorizontalInput = Input.GetAxis("LookHorizontal");
        lookVerticalInput = Input.GetAxis("LookVertical");

        if (Input.GetButtonDown("Pistol"))
        {
            pistol = true; 
            machineGun = false;
            shotgun = false;
            changeGun(1);

            gameManager.GetComponent<GameManager>().SetWeapon("pistol");
        }
        
        if (Input.GetButtonDown("MachineGun"))
        {
            machineGun = true;
            pistol = false;
            shotgun = false;
            changeGun(2);

            gameManager.GetComponent<GameManager>().SetWeapon("machinegun");
        }
        
        if (Input.GetButtonDown("Shotgun"))
        {
            shotgun = true;
            machineGun = false;
            pistol = false;
            changeGun(3);

            gameManager.GetComponent<GameManager>().SetWeapon("shotgun");
        }
        
        if (Input.GetButtonDown("Empty"))
        {
            machineGun = false;
            pistol = false;
            shotgun = false;
            changeGun(0);

            gameManager.GetComponent<GameManager>().SetWeapon("empty");
        }

        timeToFire = timeToFire -= Time.deltaTime;

        if (lookVerticalInput != 0 && timeToFire <= 0)
        {
            isShooting = true;
            timeToFire = timeToFireInterval;
        }
        
        if (lookHorizontalInput != 0 && timeToFire <= 0)
        {
            isShooting = true;
            timeToFire = timeToFireInterval;
        }

        if (Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Running", true);
        }

        else
        {
            animator.SetBool("Running", false);
        }

        animator.SetBool("Pistol", pistol);
        animator.SetBool("Shooting", isShooting);
        animator.SetBool("MachineGun", machineGun);
        animator.SetBool("Shotgun", shotgun);
        
        if (lookVerticalInput == 0 && lookHorizontalInput == 0)
        {
            isShooting = false;
        }
    }

    public void changeGun(int gun)
    {
        currentGun = gun;
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == gun)
            {
                guns[i].SetActive(true);
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }
}
