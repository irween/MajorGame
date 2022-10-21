using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    // guns
    public int currentGun; // the current gun
    public List<GameObject> guns; // list of available guns

    // ammo
    public GameObject ammoText; // ammo ui object
    private int ammoAmount; // ammo amount

    // gun shooting intervals
    public float timeToFirePistol;
    public float timeToFireMachinegun;
    public float timeToFireShotgun;

    private float timeToFireInterval; // interval between each shot
    private float timeToFire; // the time to fire

    // animation bools
    public bool isShooting = false;
    public bool pistol = false;
    public bool machineGun = false;
    public bool shotgun = false;

    private float lookHorizontalInput;
    private float lookVerticalInput;

    // sets objects
    private GameObject weaponManager;
    private Animator animator;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // finds objects and components
        gameManager = FindObjectOfType<GameManager>();
        weaponManager = GameObject.Find("WeaponsUI");
        animator = GetComponent<Animator>();

        // sets the weapon ui to empty
        weaponManager.GetComponent<WeaponUI>().SetWeapon("EmptySlot");

        // sets each gun object to not display
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // gets horizontal and vertical inputs
        lookHorizontalInput = Input.GetAxis("LookHorizontal"); // left, right - returns -1 and 1
        lookVerticalInput = Input.GetAxis("LookVertical"); // up, down - returns 1 and -1

        // checks if the player pressed the corresponding key
        if (Input.GetButtonDown("Pistol"))
        {
            // sets the current gun animation
            pistol = true;
            machineGun = false;
            shotgun = false;
            changeGun(1); // sets the current gun
            timeToFireInterval = timeToFirePistol; // sets the interval between each shot

            // sets weapon ui to pistol
            weaponManager.GetComponent<WeaponUI>().SetWeapon("Pistol");
        }

        // checks if the player pressed the corresponding key
        if (Input.GetButtonDown("MachineGun"))
        {
            // sets the current gun animation
            machineGun = true;
            pistol = false;
            shotgun = false;
            changeGun(2); // sets the current gun
            timeToFireInterval = timeToFireMachinegun; // sets the interval between each shot

            // sets weapon ui to machinegun
            weaponManager.GetComponent<WeaponUI>().SetWeapon("MachineGun");
        }

        // checks if the player pressed the corresponding key
        if (Input.GetButtonDown("Shotgun"))
        {
            // sets the current gun animation
            shotgun = true;
            machineGun = false;
            pistol = false;
            changeGun(3); // sets the current gun
            timeToFireInterval = timeToFireShotgun; // sets the interval between each shot

            // sets weapon ui to shotgun
            weaponManager.GetComponent<WeaponUI>().SetWeapon("Shotgun");
        }
        
        // checks if the player pressed the corresponding key
        if (Input.GetButtonDown("Empty"))
        {
            // sets the current gun animation
            machineGun = false;
            pistol = false;
            shotgun = false;
            changeGun(0); // sets the current gun

            // sets the weapon ui to empty
            weaponManager.GetComponent<WeaponUI>().SetWeapon("EmptySlot");
        }

        timeToFire -= Time.deltaTime; // removes time from time to fire
        timeToFire = Mathf.Clamp(timeToFire, 0, 5); // clamps time to fire between 0 and 5
        
        // checks if look inputs are pressed and time to fire is 0
        if ((lookHorizontalInput != 0 && timeToFire == 0) | (lookVerticalInput != 0 && timeToFire == 0))
        {
            isShooting = true; // sets shooting animation to true
            timeToFire = timeToFireInterval; // resets time to fire
        }
        else
        {
            isShooting = false; // sets shooting animation to false
        }

        // checks if WASD keys are pressed
        if (Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Running", true); // sets running animation to true
        }

        else
        {
            animator.SetBool("Running", false); // sets running animation to false
        }

        // sets animations
        animator.SetBool("Pistol", pistol);
        animator.SetBool("Shooting", isShooting);
        animator.SetBool("MachineGun", machineGun);
        animator.SetBool("Shotgun", shotgun);
    }

    // called by self
    // changes the current gun to the gun int 
    // sets the corresponding gun to display 
    // changes ammo text to match gun
    public void changeGun(int gun)
    {
        currentGun = gun; // makes current gun equal to gun int

        // loops for the amount of gun objects there are
        for (int i = 0; i < guns.Count; i++)
        {
            // checks if the current gun int matches the gun int
            if (i == gun)
            {
                // sets current gun to active
                guns[i].SetActive(true);

                // sets the ammo text to match the current gun
                if (i == 1)
                {
                    ammoAmount = gameManager.GetComponent<AmmoManager>().pistolAmmo;
                    ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
                }

                if (i == 2)
                {
                    ammoAmount = gameManager.GetComponent<AmmoManager>().machinegunAmmo;
                    ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
                }

                if (i == 3)
                {
                    ammoAmount = gameManager.GetComponent<AmmoManager>().shotgunAmmo;
                    ammoText.GetComponent<AmmoUIManager>().UpdateAmmo(ammoAmount);
                }
            }
            else
            {
                // sets other guns to inactive
                guns[i].SetActive(false);
            }
        }
    }
}
