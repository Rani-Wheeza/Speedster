using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBooster : BoosterBase
{
    public GameObject SpeedBoostScript;
    public GameObject SpeedDown;
    public GameObject HealthPowerUp;

    public GameObject[] boosters;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllBoosters();
    }

    private void spawnAllBoosters()
    {
       foreach(Transform t in spawnPoints)
        {
            spawnRandomBoosterAt(t.position);

        }
    }

    private void spawnRandomBoosterAt(Vector3 pos)
    {
        int boosterType = Random.Range(0, 3);
        GameObject selectBooster = null;

        switch (boosterType)
        {
            case 0:
                selectBooster = SpeedBoostScript;
                break;
            case 1:
                selectBooster = SpeedDown;
                break;
            case 2:
                selectBooster = HealthPowerUp;
                break;

        }

        GameObject newBoostGO = Instantiate(selectBooster, pos, Quaternion.identity);
        BoosterBase newBoost = newBoostGO.GetComponent<BoosterBase>();
        newBoost.Iam(this);
    }

    internal void respawnMe(Vector3 position)
    {
        StartCoroutine(spawnAt(position));
    }


    IEnumerator spawnAt(Vector3 position)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(10);

        // Execute the command
        Debug.Log("Command executed after 10 seconds!");
        spawnRandomBoosterAt(position);
        // Replace the above line with your desired functionality
    }

}

    
