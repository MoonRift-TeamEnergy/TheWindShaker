using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] float power = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = collision.transform.position - transform.position;
        collision.rigidbody.AddForce(transform.up * power, ForceMode.Impulse);
       
    }
    
}

