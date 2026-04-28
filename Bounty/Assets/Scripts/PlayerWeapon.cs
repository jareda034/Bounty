using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform BulletPoint;
    [SerializeField] float rifleFireRate = 2f;
    [SerializeField] int playerAmmo;

    int rilfeAmmo = 30;
    bool hasRifle;
    public bool isReloading;
    bool canShoot = true;
    bool isFiring;

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
        if (playerMovement.isMoving || isReloading || !canShoot) { return; }
        if (value.isPressed)
        {
            canShoot = false;
            ShootWeapon();
            anim.SetTrigger("shooting");
            playerAmmo--;
            Invoke(nameof(ResetShoot), rifleFireRate);
            if (playerAmmo == 0)
            {
                anim.SetBool("isReloading", true);
                isReloading = true;
                Invoke(nameof(ResetReload), 0.5f);
            }
        }
    }

    void ResetReload()
    {
        isReloading = false;
        playerAmmo = rilfeAmmo;
        anim.SetBool("isReloading", false);
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    void ShootWeapon()
    {
        Instantiate(bullet, BulletPoint.position, BulletPoint.rotation);
    }
}
