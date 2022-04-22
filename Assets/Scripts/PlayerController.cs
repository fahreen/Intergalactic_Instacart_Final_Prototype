
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

// this makes sure that when we add this script to a gameobject, it will add these components for us, if it doesn't have it already
[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] // so we can change in inspector
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed =5f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float bulletMissDistance = 25f;
    [SerializeField]
    private float animationSmoothTime = 0.1f;
    [SerializeField]
    private float animationPlayTransition = 0.15f;
    [SerializeField]
    private Transform aimTarget;

    [SerializeField]
    private bool shootState;
    
    public Rig armRig;
    public Rig aimRig;
    public GameObject Weapon;
    [SerializeField]
    private Canvas reticleCanvas;
    [SerializeField]
    private Canvas aimCanvas;



    [SerializeField]
    private float aimDistance = 1f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    // for getting input
    private PlayerInput playerInput;

    private InputAction moveAction;

    private InputAction jumpAction;

    private InputAction shootAction;

    private InputAction changeStateAction;

    // animation values
    private Animator animator;
    int moveXAnimationParameterID;
    int moveZAnimationParameterID;
    int jumpAnimation;


    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;

    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
        this.playerInput = this.GetComponent<PlayerInput>();
        // to access to controls, we can inddex into them with strings
        moveAction = playerInput.actions["Move"];
        cameraTransform = Camera.main.transform;
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        changeStateAction = playerInput.actions["StateChange"];

      //  Cursor.lockState = CursorLockMode.Locked;

        // Animations
        animator = this.GetComponent<Animator>();
        moveXAnimationParameterID = Animator.StringToHash("Movex");
        moveZAnimationParameterID = Animator.StringToHash("Movez");
        jumpAnimation = Animator.StringToHash("PistolJump");

        shootState = false;
    }


    private void OnEnable()
    {
        shootAction.performed += _ => ShootGun();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => ShootGun();
    }



    private void ShootGun()
    {
        // only shoot gun if equipped
        if (shootState) { 
        RaycastHit hit;
        // instantiate bullet 
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        
        // if our raycast hits sometihing
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity ))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;

        }
        // if we do not hit anything
        else
        {
            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletMissDistance ;
            bulletController.hit = false;
        }
        }

    }




    void Update()
    {
        // handle equip
        if (changeStateAction.triggered)
        {
            if (Manager.inCombat)
            {
                if (shootState)
                {
                    shootState = false;
                }
                else
                {
                    shootState = true;
                }


            }
          



        }

        if (!shootState)
        {
            this.armRig.weight = 0;
            this.aimRig.weight = 0;
            Weapon.SetActive(false);
            this.reticleCanvas.enabled = false;
            this.aimCanvas.enabled = false;
            // turn off aim camera
            // turn off reticals
        }
        else
        {
            this.armRig.weight = 1;
            this.aimRig.weight = 1;
            Weapon.SetActive(true);
        
            // turn on aim camera
            // turn on reticals
        }


        aimTarget.position = cameraTransform.position + cameraTransform.forward * aimDistance;
        // chack if player is grounded, if yes, set y velocity to 0
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        // get input from user
        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        Vector3 move = new Vector3(currentAnimationBlendVector.x,0, currentAnimationBlendVector.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        // moving player based on input
        controller.Move(move * Time.deltaTime * playerSpeed);
        animator.SetFloat(moveXAnimationParameterID, currentAnimationBlendVector.x);
        animator.SetFloat(moveZAnimationParameterID, currentAnimationBlendVector.y);


        // Jump code
        if (jumpAction.triggered && groundedPlayer && shootState)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }



      
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // rotate player, get rotation from camera
     Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
    }
}