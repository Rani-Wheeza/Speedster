using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBooster : MonoBehaviour
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
        StartCoroutine(SpawnBoosters());
    }

    IEnumerator SpawnBoosters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Transform spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)];

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

            Instantiate(selectBooster, spawnLocation.position, Quaternion.identity);

            //GameObject boosterPrefab = boosters[Random.Range(0, boosters.Length)];
            //Not sure if this needed for this

            
        }
    }
}

    
