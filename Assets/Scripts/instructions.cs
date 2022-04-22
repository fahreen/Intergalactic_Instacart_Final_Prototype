using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject insCanvas;
    public GameObject phoneCanvas;
    private void Start()
    {
        phoneCanvas.SetActive(true);

        Manager.inCombat = true;
        insCanvas.SetActive(true);
        StartCoroutine(delay());
    }



    private void Update()
    {
        if (Manager.gameOver)
        {
            phoneCanvas.SetActive(false);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        insCanvas.SetActive(false);
    }
}
