using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
   [SerializeField] GameObject rifle;
   [SerializeField] GameObject bullet;
   [SerializeField] Transform BulletPoint;
   bool hasRifle;
   Animator anim;
   PlayerMovementController playerMovement;

   void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovementController>();
    }

    void Start()
    {
        rifle.SetActive(true);
        if (rifle == true)
        {
            hasRifle = true;
        }
    }

    void Update()
    {
        CheckIfWeapon();
    }

    void CheckIfWeapon()
    {
        if (hasRifle)
        {
            anim.SetBool("HasRifle", true);
        }
        if (playerMovement.isMoving == true)
        {
            anim.SetBool("HasRifle", false);
        }
    }

    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
          ShootWeapon(); 
          Debug.Log("Bang");
        }
    }

    void ShootWeapon()
    {
       Instantiate(bullet,BulletPoint);
    }
}
