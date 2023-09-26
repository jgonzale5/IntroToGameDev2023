using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //The key the player needs to press for shooting
    //public KeyCode shootKey;
    public string shootButton;

    //The projectile that we'll be shooting
    public Transform projectile;
    //How many seconds pass between each shot
    public float fireRate;
    //An internal counter used to keep track of time passed between shots
    float fireCooldown = 0;

    private void Start()
    {
        //Set the cooldown to the rate so we can start shooting from frame 1
        fireCooldown = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //Add the delta time to the fire cooldown
        fireCooldown += Time.deltaTime;

        //If the cooldown has reached the rate
        if (fireCooldown >= fireRate 
            //&& Input.GetButton(shootButton))
            && Input.GetButtonDown(shootButton))
            //&& Input.GetButtonUp(shootButton))
        {
            //Call the Shoot function 
            Shoot();

            //Reset the cooldown
            fireCooldown = 0;
        }
    }

    void Shoot()
    {
        //The projectile is spawned at the position of this transform 

        //with the default rotation
        //Instantiate(projectile, transform.position, Quaternion.identity);

        //with the muzzle's rotation
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
