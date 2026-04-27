using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    // Variables
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 0.15f;
    Rigidbody rb;
    Vector3 playerMovement, rotationTarget;
    Vector2 mouseLook;
    Animator anim;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MousePosition();
        RotatePlayer();
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        mouseLook = value.Get<Vector2>();
    }


    void MousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseLook);
        if (Physics.Raycast(ray, out hit))
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
}
