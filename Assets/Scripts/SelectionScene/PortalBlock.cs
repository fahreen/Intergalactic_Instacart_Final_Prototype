using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBlock : MonoBehaviour
{
   public  GameObject warningCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            warningCanvas.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        warningCanvas.SetActive(false);
    }
}
