using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBox : MonoBehaviour
{
    [SerializeField] float windPower = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerControllerWithAnimations>(out PlayerControllerWithAnimations player))
        {
            player.PushVector(transform.right * windPower);
        }
        else if (other.TryGetComponent<PlayerBackGround>(out PlayerBackGround playerBackgorund))
        {
            playerBackgorund.PushVector(transform.right * windPower);
        }
       
    }
   
}
