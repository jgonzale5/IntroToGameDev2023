using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRingScript : MonoBehaviour
{
    [Header("Collision Detection")]
    //The tag that must ne on the other object of the trigger interaction for
    //points to be added.
    public string scoringTag = "Player";

    [Header("Particle Effect")]
    //The prefab of the particle effect that's gonna play when this ring is scored
    public Transform ringExplosion;

    [Header("Faking Destruction")]
    //The mesh of the ring, so that we can hide it
    public GameObject ringMesh;
    //The collider of the ring, so we can disable it
    public Collider ringCollider;

    [Header("Sound")]
    //The audio source that will play the scoring sound
    public AudioSource ringSoundPlayer;
    //The sound that will be played when points are scored with this ring
    public AudioClip scoreSound;

    private void Start()
    {
        //We tell the audio source what clip it will play
        ringSoundPlayer.clip = scoreSound;
    }

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

            //Spawn a ring explosion at the position of this object, with its
            //same rotation.
            Instantiate(ringExplosion, 
                this.transform.position, 
                this.transform.rotation,
                this.transform);

            //We destroy this object
            //Destroy(this.gameObject);

            //Instead of destroying this object, we're going to hide the ring
            //and the collider so the player thinks it's destroyed.
            ringMesh.SetActive(false);
            ringCollider.enabled = false;

            //Tell the player to play the sound assigned to its "clip" variable
            ringSoundPlayer.Play();
        }
    }
}
