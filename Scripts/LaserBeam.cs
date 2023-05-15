using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField]
    Transform _startPos;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        lr.SetPosition(0, _startPos.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
          
        }
        else
            lr.SetPosition(1, transform.right * 5000);
    
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Player"))
    //    {
            
    //        GameObject.FindObjectOfType<Player>().OnDamaged();
          
    //    }
    //}
}
