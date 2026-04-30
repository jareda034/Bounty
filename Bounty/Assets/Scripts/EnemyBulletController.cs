using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float damage = 5f;
    [SerializeField] float bulletSpeed = 5f;

     void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
        Destroy(gameObject, 4f);
    }
}
