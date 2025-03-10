using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class CityCarMovement : MonoBehaviour,IHealth
{
    float speed = 0f;
    private float speedMultiplier = 0f;
    private float accerationTime = 5f;
    private float elapsedTime = 0f;
    public float accelation = 20;
    float turningSpeed = 45f;
    Rigidbody rb;
    int health = 100;
    HealthbarScript carHealth;
    int currentHealth = 100;

    //public float speed = 1500f; // Normal speed
    public float maxSpeed = 200f; // Max speed limit
    private float defaultSpeed;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carHealth = FindObjectOfType<HealthbarScript>();
        carHealth.SetHealth(health);
        defaultSpeed = speed;
        
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        carHealth.SetHealth(health);
        print(health);
    }

    /*public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Prevent overhealing
        }

        HealthbarScript.UpdateHealthBar(currentHealth, maxHealth); // Update UI if needed
    }*/

    public IEnumerator ActivateSpeedBoost(float boostAmount, float duration)
    {
        speed += boostAmount; // Increase speed
        speed = Mathf.Clamp(speed, defaultSpeed, maxSpeed); // Keep speed within limit

        yield return new WaitForSeconds(duration); // Wait for the boost duration

        speed = defaultSpeed; // Reset to normal speed
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical"); // Get player input
        rb.AddForce(transform.forward * move * speed * Time.deltaTime, ForceMode.Acceleration);
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

    internal void RestoreHealth(int healthAmount)
    {
        throw new NotImplementedException();
    }
}
