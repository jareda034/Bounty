using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] float playerHealth = 20f;
    bool playerAlive = true;
    [Header("References")]
    Animator anim;
    [Header("Audio Settings")]
    [SerializeField] AudioClip hurtSound;
    [Range(0, 1)][SerializeField] float volume;
    [SerializeField] AudioClip deathSound;
    [Range(0, 1)][SerializeField] float deathVolume;
    [Header("Death UI")]
    [SerializeField] GameObject deathUI;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
        anim.SetTrigger("damaged");
        if (playerHealth > 2)
        {
            PlayAudio(hurtSound, volume);
        }
        if (playerHealth <= 0)
        {
            PlayAudio(deathSound, deathVolume);
            Death();
        }
    }
    public void HealPlayer(float heal)
    {
        playerHealth += heal;
        if (playerHealth > 20f)
        {
            playerHealth = 20f;
        }
    }

    void Death()
    {
        anim.SetTrigger("dead");
        playerAlive = false;
        Destroy(gameObject, 5f);
        Invoke(nameof(ShowDeathScreen), 4f);
    }

    void ShowDeathScreen()
    {
        Time.timeScale = 0f;
        deathUI.SetActive(true);
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    public bool GetPlayerAlive()
    {
        return playerAlive;
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }
}
