using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [Header("bullet Settings")]
    [SerializeField] float bulletDamage = 5f;
    [SerializeField] float bulletSpeed = 5f;

    [Header("Ref")]
    PlayerHealth player;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerHealth>();
    }

     void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
        Destroy(gameObject, 4f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

          if (player != null)
            {
                player.DamagePlayer(bulletDamage);
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Door") || other.gameObject.CompareTag("Decorations"))
        {
            Destroy(gameObject);
        }
    }
}
