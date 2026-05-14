using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    // Variables
    [Header("Player Movement Settings")]
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 0.15f;


    public bool isMoving;

    [Header("Reference Settings")]
    [SerializeField] LayerMask mouseInteractLayer;
    Rigidbody rb;
    Vector3 playerMovement, rotationTarget;
    Vector2 mouseLook;
    Animator anim;
    PlayerWeapon weapon;
    DoorController[] doorControllers;
    ToggleDeskTop toggleDeskTop;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        weapon = GetComponent<PlayerWeapon>();
        doorControllers = FindObjectsByType<DoorController>(FindObjectsSortMode.None);
        toggleDeskTop = FindAnyObjectByType<ToggleDeskTop>();
    }

    void FixedUpdate()
    {
        MousePosition();
        RotatePlayer();
        CheckMovement();
    }

    void OnMove(InputValue value)
    {
        if (weapon.isReloading || toggleDeskTop.IsUIOpen()) { return; }
        playerMovement = value.Get<Vector2>();
    }

    void CheckMovement()
    {
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
        }
    }
}
