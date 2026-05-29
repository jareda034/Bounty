using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    // Variables
    [Header("Player Movement Settings")]
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 0.15f;
    Vector3 gravityScale = new Vector3(0, -50.0f, 0);
    Vector2 inputMovement;
    public bool isMoving;

    [Header("Reference Settings")]
    [SerializeField] LayerMask mouseInteractLayer;
    Rigidbody rb;
    Vector3 playerMovement, rotationTarget;
    Vector2 mouseLook;
    Animator anim;
    PlayerWeapon weapon;
    PlayerHealth playerHealth;
    DoorController[] doorControllers;
    ToggleDeskTop toggleDeskTop;
    KeyPadController keyPadController;
    KeyPadController currentKeyPad;
    SurvivorController survivorController;
    SurvivorController currentSuvivor;
    PauseMenuController pauseMenu;
    Objective4 objective4;
    DoorController currentDoor;
    [SerializeField] GameObject controlComputer;
    [Header("UI Settings")]
    [SerializeField] GameObject interactUI;
    float interactionRange = 3f;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        weapon = GetComponent<PlayerWeapon>();
        doorControllers = FindObjectsByType<DoorController>(FindObjectsSortMode.None);
        toggleDeskTop = FindAnyObjectByType<ToggleDeskTop>();
        keyPadController = FindAnyObjectByType<KeyPadController>();
        survivorController = FindAnyObjectByType<SurvivorController>();
        objective4 = FindAnyObjectByType<Objective4>();
        pauseMenu = FindAnyObjectByType<PauseMenuController>();
        playerHealth = GetComponent<PlayerHealth>();
        Physics.gravity = gravityScale;
    }

    void FixedUpdate()
    {
        MousePosition();
        RotatePlayer();
        CheckMovement();
        ShowInteractUI();
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    void CheckMovement()
    {
        if (weapon.isReloading || toggleDeskTop.IsUIOpen() || keyPadController.KeyPadOpen() || survivorController.IsDialgueOpen() || !playerHealth.GetPlayerAlive())
        {
            playerMovement = Vector3.zero;
        }

        if (playerMovement.magnitude > 0.1f)
        {
            anim.SetBool("isMoving", true);
            isMoving = true;
        }
        else
        {
            anim.SetBool("isMoving", false);
            isMoving = false;
        }
    }

    void OnLook(InputValue value)
    {
        mouseLook = value.Get<Vector2>();
    }


    void MousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseLook);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mouseInteractLayer))
        {

            rotationTarget = hit.point;
        }
    }

    void RotatePlayer()
    {
        var lookPos = rotationTarget - transform.position;
        lookPos.y = 0f;
        var rotation = Quaternion.LookRotation(lookPos);
        Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }

        Vector3 movement = new Vector3(playerMovement.x * playerSpeed, rb.linearVelocity.y, playerMovement.y * playerSpeed);
        rb.linearVelocity = movement;

        Vector3 localmove = transform.InverseTransformDirection(movement);

        anim.SetFloat("MoveX", localmove.x);
        anim.SetFloat("MoveY", localmove.z);
    }

    void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            foreach (DoorController door in doorControllers)
            {
                door.OpenDoor();
                door.SecurityDoor();
            }
            toggleDeskTop.ToggleUI();
            keyPadController.OpenKeyPad();
            survivorController.OpenDialogue();
            objective4.UseComputer();
        }
    }

    void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            pauseMenu.OpenMenu();
        }
    }

    void ShowInteractUI()
    {
        if (toggleDeskTop != null)
        {
             if (Vector3.Distance(transform.position, toggleDeskTop.transform.position) <= interactionRange)
            {
                ClearAllInteractions();
                InterctUIActive();
                return;
            }
        }

        if (survivorController != null)
        {
            if (Vector3.Distance(transform.position, survivorController.transform.position) <= interactionRange)
            {
                ClearAllInteractions();
                currentSuvivor = survivorController;
                InterctUIActive();
                return;
            }
        }
        if (keyPadController != null)
        {
            if (Vector3.Distance(transform.position, keyPadController.transform.position) <= interactionRange)
            {
                ClearAllInteractions();
                currentKeyPad = keyPadController;
                InterctUIActive();
                return;
            }   
        }
        foreach (DoorController door in doorControllers)
        {
            if (Vector3.Distance(transform.position, door.transform.position) <= interactionRange)
            {
                currentDoor = door;
                ClearAllInteractions();
                InterctUIActive();
                return;
            }
        }

        if(controlComputer != null)
        {
            if(Vector3.Distance(transform.position,controlComputer.transform.position) <= interactionRange)
            {
                ClearAllInteractions();
                InterctUIActive();
                return;
            }
        }

        currentDoor = null;
        InterctUIOff();

    }

    void ClearAllInteractions()
    {
        currentKeyPad = null;
        currentDoor = null;
        currentSuvivor = null;
    }

    public void InterctUIActive()
    {
        interactUI.SetActive(true);
    }

    public void InterctUIOff()
    {
        interactUI.SetActive(false);
    }


}
