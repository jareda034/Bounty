using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]
    RandomEnemyPatrol randomEnemyPatrol;

    [Header("Health Settings")]
    [SerializeField] float enemyHealth;
    bool enemyDamaged = false;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        randomEnemyPatrol = GetComponent<RandomEnemyPatrol>();
    }

    void Update()
    {
        RemoveDamage();
    }

    public void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
        enemyDamaged = true;
        anim.SetTrigger("damaged");

          if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool GetEnemyDamaged()
    {
        return enemyDamaged;
    }

    void RemoveDamage()
    {
        if (randomEnemyPatrol.GetPlayerInAttackRange()== true)
        {
            enemyDamaged = false;
        }
    }

}
