using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : BoosterBase
{
   
    //int healthAmount = 20; // How much health it restores
    public int healthIncrease = 10; // Add amount to health
    private bool isCollected = false; //to private multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        if(!isCollected && other.CompareTag("Car"))
        {
            IHealth carHealth = other.GetComponent<IHealth>();
            if (carHealth != null)
            {
                carHealth.takeHealth(healthIncrease);
                isCollected = true;
               

                Destroy(gameObject); //Remove the power-up object

                manager.respawnMe(transform.position);
            }
        }
    }


}
