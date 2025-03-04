using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carHealth = FindObjectOfType<HealthbarScript>();
        carHealth.SetHealth(health);
    }

    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        carHealth.SetHealth(health);
        print(health);
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
}
