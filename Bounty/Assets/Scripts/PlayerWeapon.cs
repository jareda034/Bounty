using System.ComponentModel;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform BulletPoint;
    [SerializeField] float rifleFireRate = 2f;
    [SerializeField] int playerMaxAmmo = 90;
    [SerializeField] int loadedAmmo;

    int rilfeAmmo = 30;
    bool hasRifle;
    public bool isReloading;
    bool canShoot = true;
    bool isFiring;

    [Header("References")]
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
            loadedAmmo = rilfeAmmo;
        }
    }

    void Update()
    {
        CheckIfWeapon();
        CanShoot();
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
        isFiring = value.isPressed;
    }

    void CanShoot()
    {
        if (playerMovement.isMoving || isReloading || !canShoot) { return; }
        if (isFiring && loadedAmmo > 0)
        {
            HandleShoot();
        }
    }

    void HandleShoot()
    {
        canShoot = false;
        ShootWeapon();
        anim.SetTrigger("shooting");
        loadedAmmo--;
        Invoke(nameof(ResetShoot), rifleFireRate);
        if (playerMaxAmmo <= 0) { return; }
        if (loadedAmmo == 0)
        {
            anim.SetBool("isReloading", true);
            isReloading = true;
            Invoke(nameof(ResetReloadOnEmpty), 1.8f);
        }
    }

    void OnReload(InputValue value)
    {
        if ( playerMovement.isMoving || isReloading || loadedAmmo == rilfeAmmo || playerMaxAmmo <= 0) { return;}
        isReloading = true;
        anim.SetBool("isReloading", true);
        Invoke(nameof(ResetReload), 1.8f);
    }

    void ResetReload()
    {
        isReloading = false;
        int ammoNeeded = rilfeAmmo - loadedAmmo;
        if (playerMaxAmmo >= ammoNeeded)
        {
            loadedAmmo += ammoNeeded;
            playerMaxAmmo -= ammoNeeded;
        }
        anim.SetBool("isReloading", false);
    }

    void ResetReloadOnEmpty()
    {
        isReloading = false;
        loadedAmmo = rilfeAmmo;
        playerMaxAmmo -= rilfeAmmo;
        anim.SetBool("isReloading", false);
        Debug.Log(playerMaxAmmo);
        Debug.Log(loadedAmmo);
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    void ShootWeapon()
    {
        Instantiate(bullet, BulletPoint.position, BulletPoint.rotation);
    }

    public void AddAmmo(int amount)
    {
        playerMaxAmmo += amount;
    }

    public int GetLoadedAmmo()
    {
        return loadedAmmo;
    }

    public int GetMaxAmmo()
    {
        return playerMaxAmmo;
    }
}
