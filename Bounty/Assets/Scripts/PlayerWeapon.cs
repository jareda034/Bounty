using System.ComponentModel;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform BulletPoint;
    Animator anim;
    PlayerMovementController playerMovement;
    ToggleDeskTop toggleDeskTop;
    KeyPadController keyPadController;
    SurvivorController survivorController;
    PauseMenuController pauseMenu;
    [Header("Weapon Settings")]
    [SerializeField] float rifleFireRate = 2f;
    [SerializeField] int playerMaxAmmo = 90;
    [SerializeField] int loadedAmmo;
    int rilfeAmmo = 30;
    bool hasRifle;
    public bool isReloading;
    bool canShoot = true;
    bool isFiring;
    [Header("Audio Settings")]
    [SerializeField] AudioClip gunSound;
    [Range(0, 1)][SerializeField] float volume;
    [SerializeField] AudioClip reloadSound;
    [Range(0, 1)][SerializeField] float realodVolume;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovementController>();
        toggleDeskTop = FindAnyObjectByType<ToggleDeskTop>();
        keyPadController = FindAnyObjectByType<KeyPadController>();
        survivorController = FindAnyObjectByType<SurvivorController>();
        pauseMenu = FindAnyObjectByType<PauseMenuController>();
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
        if (playerMovement.isMoving || isReloading || !canShoot || toggleDeskTop.IsUIOpen() || keyPadController.KeyPadOpen() || survivorController.IsDialgueOpen() || pauseMenu.GetMenuOpen()) { return; }
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
    }

    void OnReload(InputValue value)
    {
        if (playerMovement.isMoving || isReloading || loadedAmmo == rilfeAmmo || playerMaxAmmo <= 0) { return; }
        isReloading = true;
        anim.SetBool("isReloading", true);
        PlayAudio(reloadSound, realodVolume);
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
        else
        {
            loadedAmmo += playerMaxAmmo;
            playerMaxAmmo = 0;
        }
        anim.SetBool("isReloading", false);
    }

    void PlayAudio(AudioClip clip, float volume)
    {
       AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    void ShootWeapon()
    {
        Instantiate(bullet, BulletPoint.position, BulletPoint.rotation);
        PlayAudio(gunSound, volume);
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
