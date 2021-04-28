using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
       Quaternion _rotation = transform.rotation;
        _rotation *= Quaternion.Euler(0, 0, -1);
        transform.rotation = Quaternion.Slerp(_rotation, transform.rotation, Time.deltaTime);
        Debug.Log("i am runing");
    }
}
