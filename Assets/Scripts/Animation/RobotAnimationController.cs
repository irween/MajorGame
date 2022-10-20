using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    private Animator animator;

    public int currentGun;
    public GameObject[] guns;

    private float lookHorizontalInput;
    private float lookVerticalInput;

    public float timeToFirePistol;
    public float timeToFireMachinegun;
    public float timeToFireShotgun;

    private float timeToFireInterval;

    private float timeToFire;

    public bool isShooting = false;
    public bool pistol = false;
    public bool machineGun = false;
    public bool shotgun = false;

    private GameObject weaponManager;
    // Start is called before the first frame update
    void Start()
    {
        weaponManager = GameObject.Find("WeaponsUI");

        animator = GetComponent<Animator>();

        weaponManager.GetComponent<WeaponUI>().SetWeapon("EmptySlot");

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
            timeToFireInterval = timeToFirePistol;

            weaponManager.GetComponent<WeaponUI>().SetWeapon("Pistol");
        }
        
        if (Input.GetButtonDown("MachineGun"))
        {
            machineGun = true;
            pistol = false;
            shotgun = false;
            changeGun(2);
            timeToFireInterval = timeToFireMachinegun;

            weaponManager.GetComponent<WeaponUI>().SetWeapon("MachineGun");
        }
        
        if (Input.GetButtonDown("Shotgun"))
        {
            shotgun = true;
            machineGun = false;
            pistol = false;
            changeGun(3);
            timeToFireInterval = timeToFireShotgun;
            weaponManager.GetComponent<WeaponUI>().SetWeapon("Shotgun");
        }
        
        if (Input.GetButtonDown("Empty"))
        {
            machineGun = false;
            pistol = false;
            shotgun = false;
            changeGun(0);

            weaponManager.GetComponent<WeaponUI>().SetWeapon("EmptySlot");
        }

        timeToFire -= Time.deltaTime;
        timeToFire = Mathf.Clamp(timeToFire, 0, 5);
        
        if ((lookHorizontalInput != 0 && timeToFire == 0) | (lookVerticalInput != 0 && timeToFire == 0))
        {
            isShooting = true;
            timeToFire = timeToFireInterval;
        }
        else
        {
            isShooting = false;
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
