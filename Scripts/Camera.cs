using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Vector3 delta;
    public GameObject player;
    

    
    void LateUpdate()
    {
        transform.position = player.transform.position + delta;
        transform.LookAt(player.transform);
    }
}
