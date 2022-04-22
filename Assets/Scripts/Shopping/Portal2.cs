using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    public GameObject timeCanvas;
    public GameObject endCanvas;
    // Start is called before the first frame update
    void Start()
    {
        timeCanvas.gameObject.SetActive(true);
        endCanvas.gameObject.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.doneShopping)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
