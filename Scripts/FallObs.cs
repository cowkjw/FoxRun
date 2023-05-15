using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObs : MonoBehaviour
{
    Vector3 _startPos;
    
    void Start()
    {
        _startPos = transform.position;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("FallFloor", 0.1f);
        }
    }

    void FallFloor()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;
        Invoke("Return2StartPos", 2f);
    }

    void Return2StartPos()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        transform.position = _startPos;
    }
}
