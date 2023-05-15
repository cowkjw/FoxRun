using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
 public   float time = 0f;
    float _speed = 1f;
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 2f)
        {
            _speed *= -1;
            time = 0f;
        }
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
