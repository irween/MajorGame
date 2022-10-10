using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public List<GameObject> weapons;
    private List<Component> weaponsScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(int gun)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == gun)
            {
                weapons[i].GetComponent<GunController>().ShootGun();
            }
        }
    }
}
