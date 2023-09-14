using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //The speed of this projectile
    public float speed;

    //How long will this projectile last before self-destruction
    public float lifetime;
    //The counter that keeps track of how long this projectile has been around for
    private float lifetimeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        //We use the function (to keep update clean)
        MoveProjectile();

        //The deltatime is added to the counter
        lifetimeCounter += Time.deltaTime;

        //If the counter has exceeded the lifetime
        if (lifetimeCounter > lifetime)
        {
            //Destroy this
            Destroy(this.gameObject);
        }
    }

    void MoveProjectile()
    {
        //We define a new position vector to easily modify its values
        Vector3 newPos = transform.position;

        //We set the new position to be "speed" units along the forward direction
        //of this transform every second.
        newPos += transform.forward * speed * Time.deltaTime;

        //Set the new position of the object
        transform.position = newPos;
    }
}
