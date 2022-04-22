using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTriggerDetector : MonoBehaviour
{

   public  GameObject orderCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            orderCanvas.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        orderCanvas.SetActive(false);
    }
}
