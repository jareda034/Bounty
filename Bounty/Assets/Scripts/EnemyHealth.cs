using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 15f;

    public void DamageEnemy(float damage)
    {
        enemyHealth -= damage;
        Debug.Log(enemyHealth);

          if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
