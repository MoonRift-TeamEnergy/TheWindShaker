using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] int direction = 1;
    [SerializeField] float powerOfRotation = 0;
    [SerializeField] float TimeBetweanRotation = 0;
    Quaternion _rotation = default;
    Rigidbody rigidbody = default;

    float time = 0;
    bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        _rotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTime();
        Rotate();
     
    }


    void UpdateTime()
    {
        if(time < TimeBetweanRotation)
        {
            time += Time.fixedDeltaTime;
        }
        else if(time >= TimeBetweanRotation && transform.rotation == _rotation)
        {
            rotate = true;
            _rotation = transform.rotation;
            _rotation *= Quaternion.Euler(0, 0, 90 * Mathf.Clamp(direction, -1, 1));
            
            time = 0;
        }

    }

    void Rotate()
    {
        if (rotate)
        {
            Quaternion rotation = transform.rotation;
            rotation *= Quaternion.Euler(0, 0, 90 * Mathf.Clamp(direction, -1, 1));
            rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, _rotation, powerOfRotation * Time.fixedDeltaTime));


        }
    }
}
