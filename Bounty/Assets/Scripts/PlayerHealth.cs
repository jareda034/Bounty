using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] float playerHealth = 20f;
    bool playerAlive = true;
    [Header("References")]
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
        anim.SetTrigger("damaged");
        Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {
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
