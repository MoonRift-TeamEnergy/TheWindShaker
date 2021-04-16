using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            player.SetVilocity((transform.position - player.transform.position).normalized);
            player.SetGrounded(true);
            //Physics.gravity = updateGravity;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player.GetGrounded())
                player.SetVilocity(player.GetVilocity() * 0.5f + (transform.position - player.transform.position).normalized);
            //Physics.gravity = updateGravity;
        }
    }
}
