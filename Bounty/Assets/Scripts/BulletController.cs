using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
   [SerializeField] float bulletSpeed = 5f;
   [SerializeField] float bulletDamage = 2.5f;

   EnemyHealth enemy;

    void Awake()
    {
        enemy = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
        Destroy(gameObject,4f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
          EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();

          if (enemy != null)
            {
                enemy.DamageEnemy(bulletDamage);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
