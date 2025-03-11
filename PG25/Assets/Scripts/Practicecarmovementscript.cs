using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class carmovementscript : MonoBehaviour, IHealth
{

    //float speed = 0f;
    //private float speedMultiplier = 0f;
    //private float accerationTime = 5f;
   // private float elapsedTime = 0f;
    float accelation = 30;
    float turningSpeed = 45f;
    Rigidbody rb;
    int health = 100;
    HealthbarScript carHealth;


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

    // Start is called before the first frame update
    void Start()
    {
        carHealth = FindObjectOfType<HealthbarScript>();
        carHealth.SetHealth(health);
        rb = GetComponent<Rigidbody>();
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
            transform.Rotate(Vector3.up, -turningSpeed* Time.deltaTime); // turn left
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime); // turn right
        }

        // Normalize to ensure consistent movement speed when moving diagonally
 
       
        // Apply movement
       // transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        //// Apply forward/backward movement
        //transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);

        // Rotation (Turning) - Left and Right with A and S
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime); // Turn left
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);  // Turn right
        }

        ////Speed
        ////Will gradually incerase the speed multiper over 5 seconds
        //if (elapsedTime < accerationTime) {
        //    elapsedTime = Time.deltaTime;
        //    speedMultiplier = Mathf.Min(elapsedTime / accerationTime, 1f);
                    
        //}


  

    }
}
