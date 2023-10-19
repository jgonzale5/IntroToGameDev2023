using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //The maximum and minimum position of the ship in each axis
    public Vector2 movBoundMin; 
    public Vector2 movBoundMax;

    //The speed of the player in X and Y
    //Tooltip lets you show messages when you over over variables
    [Tooltip("The speed of the player in X and Y")]
    public float speed;

    [Header("Animations")]
    //The animator that controls the ship animations
    public Animator animator;
    //The parameter that controls the animations in X
    public string XAnimParam;
    //The parameter that controls the animations in Y
    public string YAnimParam;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        //A way to collapse code in the editor for organization
        #region Example
        //Debugging tick every second
        /*Debug.Log("Tick");*/
        /*
        Vector3 newPos = this.gameObject.transform.position;

        newPos.z += speed * Time.deltaTime;
        //Same as saying newPos.z = newPos.z + speed;

        //This is the same as saying that
        this.gameObject.transform.position = newPos;*/
        #endregion

        //We declare the variables keeping track of player input
        float xMov;
        float yMov;

        //We store the player input
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        //Forward the value of xMov and yMov to the animator. It will know
        //where to go from there.
        animator.SetFloat(XAnimParam, xMov);
        animator.SetFloat(YAnimParam, yMov);

        //We declare a variable with the motion the player is making
        //                           v Horizontal direction
        //                                 v Vertical direction
        //                                             v The speed of both directions
        //                                                    v DeltaTime to remove frame dependency
        Vector3 motion = new Vector3(xMov, yMov, 0) * speed * Time.deltaTime;

        //A temporary variable to check for boundaries
        Vector3 finalPos = transform.position + motion;

        //Fix movement in X
        if (finalPos.x > movBoundMax.x)
            finalPos.x = movBoundMax.x;
        if (finalPos.x < movBoundMin.x)
            finalPos.x = movBoundMin.x;
        
        //Fix movement in y
        if (finalPos.y > movBoundMax.y)
            finalPos.y = movBoundMax.y;
        if (finalPos.y < movBoundMin.y)
            finalPos.y = movBoundMin.y;

        //Set the correct final position
        transform.position = finalPos;

        //OLD CODE
        //We change the position by adding the motion
        //transform.position += motion;
        //Which is the same as saying
        //transform.position = transform.position + motion;

    }
}
