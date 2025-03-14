using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
   
    int healthAmount = 20; // How much health it restores

    //private void OnTriggerEnter(Collider other)
    //{
    //    CityCarMovement carHealth = other.GetComponent<CityCarMovement>();

    //    if (carHealth != null) // Check if the car has an IHealth script
    //    {
    //        carHealth.RestoreHealth(healthAmount);
    //        Destroy(gameObject); // Remove the power-up after use
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // Make sure the car has the tag "Car"
        {
            CityCarMovement carHealth = other.GetComponent<CityCarMovement>();

            if (carHealth != null)
            {
                carHealth.RestoreHealth(healthAmount);
                Destroy(gameObject); // Remove the power-up after collection
            }
        }
    }
}
