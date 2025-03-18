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
        print("Damage");
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            if (carHealth != null)
            {
                carHealth.takeDamage(2); // Reduce HP when hitting obstacles
            }
        }

        /*if (collision.gameObject.CompareTag("Boost"))
        {
            if(carHealth == null)
            {
                carHealth.takeHealth(5);
            }
        }*/
    }

    /*void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        //for when the car enters a check point or the finish line
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint reached!");
            
        }
    }*/

    
    
}

     

   
