using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class CityCarMovement : MonoBehaviour,IHealth
{
    float speed = 0f;
    float accelation = 20f;
    float deceleration = 5f;
    int turningSpeed = 45;
    Rigidbody rb;
    int health = 100;
    HealthbarScript carHealth;
    int currentHealth = 100;

    
    float maxSpeed = 200f; // Max speed limit
    private float defaultAccelation;
    private float maxHealth;
    //private int currentHealth;

    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carHealth = FindObjectOfType<HealthbarScript>();
        carHealth.SetHealth(health);
        defaultAccelation = accelation;
        
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        carHealth.SetHealth(health);
       // print(health);
    }

    public void takeHealth(int healthAmount)
    {
        health += healthAmount;
        carHealth.SetHealth(health);
        print(health);
    }

    //increase health
    /*public void RestoreHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = (int)maxHealth; // Prevent overhealing
        }

        HealthbarScript.UpdateHealthBar(currentHealth, maxHealth); // Update UI if needed
    }*/

    
    //increase speed
    public IEnumerator ActivateSpeedBoost(float boostAmount, float duration)
    {

        Debug.Log("Speed boost activated. increse speed");

        accelation += boostAmount; // Increase speed
        //accelation = Mathf.Clamp(accelation, defaultSpeed, maxSpeed); // Keep speed within limit

        //Debug.Log("New speed" + speed);

        yield return new WaitForSeconds(duration); // Wait for the boost duration

        Debug.Log("Speed boost ended. resetting speed");

        accelation = defaultAccelation; // Reset to normal speed
    }

    //decrease speed
    public IEnumerator ActivateSpeedDown(float boostAmount, float duration)
    {

        Debug.Log("Speed boost activated. decrease speed");

        accelation -= boostAmount; // Decrease speed
        //accelation = Mathf.Clamp(accelation, defaultSpeed, maxSpeed); // Keep speed within limit

        //Debug.Log("New speed" + speed);

        yield return new WaitForSeconds(duration); // Wait for the boost duration

        Debug.Log("Speed boost ended. resetting speed");

        accelation = defaultAccelation; // Reset to normal speed
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical"); // Get player input
        rb.AddForce(transform.forward * move * accelation * Time.deltaTime, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        // Initialize movement direction to zero
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(accelation * transform.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-accelation * transform.forward);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime); // turn left
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime); // turn right
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime); // Turn left
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);  // Turn right
        }
    }

    internal void ApplyBoost(float boostAmount, float boostDuration)
    {
        StartCoroutine(ActivateSpeedBoost(boostAmount, boostDuration));
    }

    internal void RestoreHealth(int healthAmount)
    {
        throw new NotImplementedException();
    }

    internal void ApplyDecrease(float decreaseAmount, float boostDuration)
    {
        throw new NotImplementedException();
    }


    /*internal void ApplySpeedDecrease(float boostAmount, float boostDuration)
    {
        StartCoroutine(ActivateSpeedDown(boostAmount, boostDuration));
    }*/
}
