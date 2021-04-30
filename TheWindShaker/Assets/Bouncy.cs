using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] Sprite[] temperarryanimator = default;
    [SerializeField] float power = 0;

    SpriteRenderer mySprite = default;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        mySprite.sprite = temperarryanimator[1];
        Vector3 direction = collision.transform.position - transform.position;
        collision.rigidbody.AddForce(transform.up * power, ForceMode.Impulse);
       
    }

    private void OnCollisionExit(Collision collision)
    {
        mySprite.sprite = temperarryanimator[0];
    }

}

