using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{

    float decreaseAmount = 30f;  // speed reduced
    float boostDuration = 5f; // duration of boost

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Object Entered decrease booster: " + other.name);

        if (other.CompareTag("Car")) // Make sure your car has the tag "Car"
        {
            Debug.Log("Decrease Booster activated");

            CityCarMovement car = other.GetComponent<CityCarMovement>();
            if (car != null)
            {
                Debug.Log("Car Found! Applying boost..");
                car.ApplyDecrease(decreaseAmount, boostDuration);

            }


            Destroy(gameObject); // Remove power-up after collection
        }
    }



    
}
