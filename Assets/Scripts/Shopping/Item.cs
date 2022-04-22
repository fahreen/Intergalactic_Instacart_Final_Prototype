using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Item : MonoBehaviour
{

    public Sprite UpdatedImage;
    public Image ImagePlacement;
    public GameObject collectCanvas;
    private bool collected;
    private bool canCollect;

    public  PlayerInput playerInput;
    private InputAction changeStateAction;


    // Start is called before the first frame update
    void Start()
    {
        collected = false;
        collectCanvas.SetActive(false);
        canCollect = false;
        changeStateAction = playerInput.actions["StateChange"];

    }

    private void Update()
    {

        if (changeStateAction.triggered && canCollect)
        {

            ImagePlacement.sprite = UpdatedImage;
            collectCanvas.SetActive(false);
            collected = true;
            Manager.itemCount++;

        }


    }



    private void OnTriggerStay(Collider other)
    {
        if (!collected && other.tag == "Player")
        {
            collectCanvas.SetActive(true);
            canCollect = true;

        }


    }

    private void OnTriggerExit(Collider other)
    {
        collectCanvas.SetActive(false);
        canCollect = false;
    }


}
