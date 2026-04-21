using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
   // Variables
   [SerializeField] float playerSpeed = 5.0f;
   Rigidbody rb;
   Vector2 playerMovement;

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
        rb.linearVelocity = movement;
    }
}
