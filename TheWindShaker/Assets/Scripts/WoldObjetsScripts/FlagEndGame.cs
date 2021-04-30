using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEndGame : MonoBehaviour
{
    [SerializeField] GameObject credits = default;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            credits.SetActive(true);
            PlayerControllerWithAnimations player = other.gameObject.GetComponent<PlayerControllerWithAnimations>();
            player.SetGrounded(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerControllerWithAnimations player = other.gameObject.GetComponent<PlayerControllerWithAnimations>();
            player.SetGrounded(false);
        }
    }
}
