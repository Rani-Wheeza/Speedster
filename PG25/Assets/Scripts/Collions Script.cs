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

    /*private void OnCollisionEnter(Collision collision)
    {

        //Check if the car collides with the wall by tag (optional)
        if (collision.gameObject.CompareTag("Wall"))
        {

            //Play crash sound
            if (crashSound != null) 
            {
                audioSource.PlayOneShot(crashSound);
            
            }

            //Apply a force to the car to simulate a crash (you can adjust crashForce)
            ApplyCrashForce(collision);

            // You could also slow down the car or do other things here
             carRigidbody.velocity = Vector3.zero;  // For example, stop the car
        }
    }

    private void ApplyCrashForce(Collision collision)
    {
        // Calculate the impact force of the collision
        Vector3 collisionNomarl = collision.contacts[0].normal;
        carRigidbody.AddForce(-collisionNomarl *  crashForce, ForceMode.Impulse);

        // You can also add a small effect like reducing speed after crash
         carRigidbody.velocity *= 0.5f; // Slow down the car after crash
    }

    
     public ParticleSystem crashParticles;  // Drag and drop particle system in the inspector

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Wall"))
    {
        // Play crash sound
        if (crashSound != null)
        {
            audioSource.PlayOneShot(crashSound);
        }

        // Trigger particles
        if (crashParticles != null)
        {
            crashParticles.transform.position = collision.contacts[0].point;
            crashParticles.Play();
        }

        // Apply crash force
        ApplyCrashForce(collision);
    }*/
}

     

    // Update is called once per frame
    /*void Update()
    {
        
    }
}*/
