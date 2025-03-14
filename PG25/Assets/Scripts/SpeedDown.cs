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

















    /*float decelerationTime = 5f; // Time in seconds to fully decelerate
    private Rigidbody carRigidbody;
    private float initialSpeed;
    private float timeElapsed;

    void Start()
    {
        // Get the Rigidbody component of the car
        carRigidbody = GetComponent<Rigidbody>();
        // Record the initial speed of the car
        initialSpeed = carRigidbody.velocity.magnitude;
        timeElapsed = 0f;
    }

    void Update()
    {
        // Only apply deceleration if car is moving and has not completed the 5 seconds
        if (timeElapsed < decelerationTime && carRigidbody.velocity.magnitude > 0.1f)
        {
            // Increment the time elapsed
            timeElapsed += Time.deltaTime;

            // Calculate the percentage of time passed and reduce speed accordingly
            float speedFactor = 1 - (timeElapsed / decelerationTime);
            carRigidbody.velocity = carRigidbody.velocity.normalized * initialSpeed * speedFactor;
        }
        else
        {
            // Ensure the velocity is zero after 5 seconds
            carRigidbody.velocity = Vector3.zero;
        }
    }*/
}
