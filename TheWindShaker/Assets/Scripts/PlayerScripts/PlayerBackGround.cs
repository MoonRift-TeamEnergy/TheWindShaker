using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackGround : MonoBehaviour
{
    Rigidbody myrb = default;
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();
    }

    


    public void PushVector(Vector3 push)
    {
        myrb.AddForce(push, ForceMode.Force);
    }
}
