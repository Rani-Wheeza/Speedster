using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollionsScript : MonoBehaviour
{
    IHealth carHealth;
    //private Rigidbody carRigidbody;
    //public float crashForce = 10f;  // The amount of force to apply to simulate a crash
    //public AudioClip crashSound;    // Sound to play when a collision happens
    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        carHealth = GetComponent<IHealth>();
        //carRigidbody = GetComponent<Rigidbody>();
        //audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collied with: " + collision.gameObject.name);
        carHealth.takeDamage(5f);
        //
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Car hit an obstacle!");
            //
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        //for when the car enters a check point or the finish line
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint reached!");
            
        }
    }

    
    
}

     

   
