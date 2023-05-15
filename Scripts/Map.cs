using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    SpawnMap spawnMap;
    
    void Start()
    {
        spawnMap = GameObject.FindObjectOfType<SpawnMap>();
    }

    private void OnTriggerExit(Collider other)
    {
        spawnMap.Spawn();
        spawnMap.Spawn();
        Destroy(gameObject, 1f);
    }
}
