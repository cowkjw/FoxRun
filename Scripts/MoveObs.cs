using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObs : MonoBehaviour
{
    float _speed = 5f;
    float maxTime = 0f;
    void FixedUpdate()
    {
        maxTime += Time.deltaTime;
        if(maxTime>1.5f)
        {
            _speed *= -1;
            maxTime = 0f;
        }
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }


}
