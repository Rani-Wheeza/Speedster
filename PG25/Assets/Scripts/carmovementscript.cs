using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class carmovementscript : MonoBehaviour, IHealth
{

    float speed = 0f;
    private float speedMultiplier = 0f;
    private float accerationTime = 5f;
    private float elapsedTime = 0f;
    float accelation = 30;
    float turningSpeed = 45f;
    Rigidbody rb;
    float health = 100;

    public void takeDamage(float damageAmount)
    {
        health -= damageAmount;
        print(health);
    }

    // Start is called before the first frame update
    void Start()
    {
      
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
