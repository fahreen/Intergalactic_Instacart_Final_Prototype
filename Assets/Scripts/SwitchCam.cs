
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class SwitchCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction aimAction;
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private int priorotyBoostAmount= 10;
    [SerializeField]
    private Canvas thirdPersonCanvas;
    [SerializeField]
    private Canvas aimCanvas;

    private void Awake()
    {
        vcam = this.GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];// right click

    }

    private void OnEnable()
    {
        //+= subscribing to the events
        aimAction.performed += _ => StartAim();
        // when we stop pressing the button
        aimAction.canceled += _ => CancelAim();
    }


    private void OnDisable()
    {
        // unsubscribing to thew events
        //+= subscribing to the events
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }



    // attach this script to the aiming camera
    private void StartAim()
    {
        vcam.Priority += priorotyBoostAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim() {
        vcam.Priority -= priorotyBoostAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }


}
