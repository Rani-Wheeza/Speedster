using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{

    public float boostAmount = 50f;  // speed added
    public float boostDuration = 5f; // duration of boost

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
                StartCoroutine(car.ActivateSpeedBoost(boostAmount, boostDuration));
            }

            else
            {
                Debug.Log("Collied with something else " + other.name);
            }

            Destroy(gameObject); // Remove power-up after collection
        }
    }


    //public float speedBoostAmount = 5f; // Adjust speed boost value
    //public float duration = 5f; // Power-up lasts 5 seconds

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car")) // Check if player collects the power-up
        {
            CityCarMovement player = other.GetComponent<CityCarMovement>();
            if (player != null)
            {
                StartCoroutine(player.SpeedBoost(duration, speedBoostAmount));
            }

            
        }
    }*/
}
