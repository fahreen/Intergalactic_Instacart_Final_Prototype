using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDelivery : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Manager.gameOver = true;
        Debug.Log("Done Delivery");
    }
}
