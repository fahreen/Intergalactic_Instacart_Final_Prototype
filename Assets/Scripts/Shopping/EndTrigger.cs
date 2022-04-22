using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    SceneLoader s = new SceneLoader();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Manager.inCombat = true;
            s.StartDelivery1();
        }
    }
}
