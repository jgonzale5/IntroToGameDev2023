using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRingScript : MonoBehaviour
{
    //The tag that must ne on the other object of the trigger interaction for
    //points to be added.
    public string scoringTag = "Player";

    //This callback function will be called when a collider on the same object
    //as this script enters a trigger (or if there is a trigger on this object
    //colliding with an object)
    private void OnTriggerEnter(Collider other)
    {
        //We display the name of the object we collided with
        //Debug.Log("Collided with object " + other.gameObject.name);

        //If the other object has the scoring tag, this object is destroyed
        if (other.CompareTag(scoringTag))
        {
            //Add 10 points to score manager, which will display the new score
            ScoreManager.Instance.AddScore(10);

            //We destroy this object
            Destroy(this.gameObject);
        }
    }
}
