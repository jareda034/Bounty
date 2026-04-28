using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform BulletPoint;
    [SerializeField] int playerAmmo;
    int rilfeAmmo = 30;
    bool hasRifle;
    public bool isReloading;
    
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
            playerAmmo = rilfeAmmo;
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
        if (playerMovement.isMoving || isReloading) { return; }
        if (value.isPressed)
        {
            ShootWeapon();
            anim.SetTrigger("shooting");
            playerAmmo--;
            if(playerAmmo == 0)
            {
                anim.SetBool("isReloading", true);
                isReloading = true;
                Invoke(nameof(ResetReload), 2f);
            }
        }
    }

    void ResetReload()
    {
        isReloading = false;
        playerAmmo = rilfeAmmo;
        anim.SetBool("isReloading", false);
    }

    void ShootWeapon()
    {
        Instantiate(bullet, BulletPoint.position, BulletPoint.rotation);
    }
}
