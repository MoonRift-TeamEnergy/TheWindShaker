using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerCannon : MonoBehaviour
{
    [SerializeField] StartCannon c = null;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        c.Fire();
    }
}
