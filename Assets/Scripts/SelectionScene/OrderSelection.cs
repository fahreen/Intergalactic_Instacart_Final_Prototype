using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSelection : MonoBehaviour
{


    public GameObject portalBlock;
    public GameObject selectionCanvas;
    public void startMission()
    {
        portalBlock.SetActive(false);
        selectionCanvas.SetActive(false);
    }
}
