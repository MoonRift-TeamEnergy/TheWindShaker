using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBox : MonoBehaviour
{
    [SerializeField] float windPower = 0;
    private void OnTriggerEnter(Collider other)
    {  
        if(other.TryGetComponent<PlayerControllerWithAnimations>(out PlayerControllerWithAnimations player))
        {
            player.PushVector = transform.right * windPower;
        }
    }
   
}
