using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
   // Variables
   [SerializeField] float playerSpeed = 5.0f;
   [SerializeField] float rotationSpeed = 360f;
   Rigidbody rb;
   Vector3 playerMovement;

   void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        Look();
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(playerMovement.x * playerSpeed, rb.linearVelocity.y, playerMovement.y * playerSpeed);
        rb.linearVelocity = movement;
    }

    void Look()
    {
        if (playerMovement == Vector3.zero) return;
        Matrix4x4 isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45 , 0));
        Vector3 multipLyMatrix = isometricMatrix.MultiplyPoint3x4(playerMovement);

        Quaternion rotation = Quaternion.LookRotation(multipLyMatrix, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
