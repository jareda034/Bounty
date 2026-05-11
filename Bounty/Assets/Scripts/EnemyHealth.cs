using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    bool enemyDamaged = false;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
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

}
