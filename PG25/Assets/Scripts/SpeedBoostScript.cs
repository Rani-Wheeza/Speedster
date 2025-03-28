using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : BoosterBase
{

    float boostAmount = 30f;  // speed added
    float boostDuration = 5f; // duration of boost

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Object Entered speed booster: " + other.name);

        if (other.CompareTag("Car")) // Make sure your car has the tag "Car"
        {
            Debug.Log("Speed Booster activated");

            CityCarMovement car = other.GetComponent<CityCarMovement>();
            if (car != null)
            {
                Debug.Log("Car Found! Applying boost..");
                car.ApplyBoost(boostAmount, boostDuration);
               
            }

           
            
            Destroy(gameObject); // Remove power-up after collection

            manager.respawnMe(transform.position);
        }
    }


    
}
