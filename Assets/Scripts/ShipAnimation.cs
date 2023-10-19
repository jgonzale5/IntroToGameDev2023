using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimation : MonoBehaviour
{
    //The animator component that will make the ship spin
    public Animator animator;
    //The name of the spin parameter to set the trigger
    public string spinParameterName;

    //When this function is called, the ship spins
    public void Spin()
    {
        //Set the spin trigger on
        animator.SetTrigger(spinParameterName);
    }
}
