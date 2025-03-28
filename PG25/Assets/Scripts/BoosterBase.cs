using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterBase : MonoBehaviour
{
    internal SpawnBooster manager;
    internal int r = 5;

    internal void Iam(SpawnBooster spawnBooster)
    {
        manager = spawnBooster;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
