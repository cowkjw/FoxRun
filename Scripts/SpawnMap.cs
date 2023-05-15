using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject _map;
    Vector3 _nextPos;
  
   public void Spawn()
    {
        GameObject prevMap = Instantiate(_map, _nextPos, Quaternion.identity);
        _nextPos = prevMap.transform.GetChild(0).transform.position;
    }
    void Start()
    {
        for(int i = 0;i<15;i++)
        Spawn();
    }

}
