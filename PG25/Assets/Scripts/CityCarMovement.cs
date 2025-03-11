using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class CityCarMovement : MonoBehaviour,IHealth
{
    public float speed = 1500f;
    //private int speedMultiplier = 0;
    //private int accerationTime = 5;
    //private int elapsedTime = 0;
    public float accelation = 20f;
    int turningSpeed = 45;
    Rigidbody rb;
    int health = 100;
    HealthbarScript carHealth;
    //int currentHealth = 100;

    //public float speed = 1500f; // Normal speed
    public float maxSpeed = 200f; // Max speed limit
    private float defaultAccelation;
    private float maxHealth;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carHealth = FindObjectOfType<HealthbarScript>();
        carHealth.SetHealth(health);
        defaultAccelation = speed;
        
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        carHealth.SetHealth(health);
        print(health);
    }

    public void takeHealth(int healthAmount)
    {
        health += healthAmount;
        carHealth.SetHealth(health);
        print(health);
    }

    /*public void RestoreHealth(int amount)
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

        Debug.Log("Speed boost activated. increse speed");

        accelation += boostAmount; // Increase speed
        //accelation = Mathf.Clamp(accelation, defaultSpeed, maxSpeed); // Keep speed within limit

        //Debug.Log("New speed" + speed);

        yield return new WaitForSeconds(duration); // Wait for the boost duration

        Debug.Log("Speed boost ended. resetting speed");

        accelation = defaultAccelation; // Reset to normal speed
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
