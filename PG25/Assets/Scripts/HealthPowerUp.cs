using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
   
    //int healthAmount = 20; // How much health it restores
    public int healthIncrease = 10; // Add amount to health
    private bool isCollected = false; //to private multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        if(!isCollected && other.CompareTag("Car"))
        {
            IHealth carHealth = other.GetComponent<IHealth>();
            if (carHealth != null)
            {
                carHealth.takeHealth(healthIncrease);
                isCollected = true;
                Destroy(gameObject); //Remove the power-up object
            }
        }
    }



    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered health booster: " + other.name);

        if (other.CompareTag("Car")) // Make sure the car has the tag "Car"
        {
            Debug.Log("Speed Booster activated");

            CityCarMovement carHealth = other.GetComponent<CityCarMovement>();

            if (carHealth != null)
            {
                Debug.Log("Car Found! Applying boost..");
                carHealth.RestoreHealth(healthAmount);

                
            }

            Destroy(gameObject); // Remove the power-up after collection
        }
    }*/
}
