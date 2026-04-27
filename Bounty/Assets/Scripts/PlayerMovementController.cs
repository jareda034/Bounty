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
    }

    void OnMove(InputValue value)
    {
        playerMovement = value.Get<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(playerMovement.x * playerSpeed, rb.linearVelocity.y, playerMovement.y * playerSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);


        rb.linearVelocity = movement;
    }
}
