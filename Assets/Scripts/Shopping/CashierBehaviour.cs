using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CashierBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject checkOutCanvas;
    public GameObject doneShoppingCanvas;
    public GameObject notDoneShoppingCanvas;
    private bool canCheckout;
    public PlayerInput playerInput;
    private InputAction changeStateAction;
   

    private void Start()
    {
        canCheckout = false;
        changeStateAction = playerInput.actions["StateChange"];

    }

    private void Update()
    {
        if ( canCheckout && changeStateAction.triggered)
        {
            checkOutCanvas.SetActive(false);
            if (Manager.itemCount == 4)
            {
                doneShoppingCanvas.SetActive(true);
                Manager.doneShopping = true;
            }
            else
            {
                notDoneShoppingCanvas.SetActive(true);

            }
           
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (!canCheckout)
        {
            checkOutCanvas.SetActive(true);
            canCheckout = true;
        }




    }

    private void OnTriggerExit(Collider other)
    {
        checkOutCanvas.SetActive(false);
        canCheckout = false;
        notDoneShoppingCanvas.SetActive(false);
    }
}
