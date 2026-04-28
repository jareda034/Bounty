using System.ComponentModel.Design;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
   [SerializeField] GameObject rifle;
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
}
