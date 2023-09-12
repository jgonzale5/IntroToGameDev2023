using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovementScript : MonoBehaviour
{
    //The speed of this object
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //Make a new temporary vector
        Vector3 newPos = transform.position;

        //The new position is equal to
        //(Original Position) + (Direction * Speed * DeltaTime (to avoid frame dependency))

        newPos += transform.forward * speed * Time.deltaTime;

        transform.position = newPos;
    }
}
