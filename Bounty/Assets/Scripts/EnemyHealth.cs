using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
        anim.SetTrigger("damaged");
        Debug.Log(enemyHealth);

          if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
