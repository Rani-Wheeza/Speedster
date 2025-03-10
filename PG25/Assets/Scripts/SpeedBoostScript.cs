using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostScript : MonoBehaviour
{

    public float boostAmount = 50f;  // How much speed is added
    public float boostDuration = 3f; // How long the boost lasts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // Make sure your car has the tag "Car"
        {
            CityCarMovement car = other.GetComponent<CityCarMovement>();
            if (car != null)
            {
                StartCoroutine(car.ActivateSpeedBoost(boostAmount, boostDuration));
            }
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

            Destroy(gameObject); // Remove power-up after collection
        }
    }*/
}
