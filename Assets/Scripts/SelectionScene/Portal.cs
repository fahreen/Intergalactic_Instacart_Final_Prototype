using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Portal : MonoBehaviour
{
    SceneLoader s = new SceneLoader();
    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            s.StartShopping1();
        }
    }
}
