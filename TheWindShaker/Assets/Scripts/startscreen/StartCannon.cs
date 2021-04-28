using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCannon : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] GameObject projectile = null;


    private void Start()
    {
        Fire();
    }

    public void Fire()
    {
        GameObject _projectile = Instantiate(projectile);
        _projectile.GetComponent<Rigidbody>().velocity = target.position;

    }
} 
