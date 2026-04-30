using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [Header("Ref")]
  [SerializeField] GameObject Bullet;
  [SerializeField] Transform firePoint;
  Animator anim;
  [Header("Attack Settings")]
  [SerializeField] float damage = 5f;
  [SerializeField] float forwardShotForce = 10f;

   void Awake()
    {
        anim = GetComponent<Animator>();
    }

  public void FireBullet()
    {
        anim.SetBool("isShooting", true);
        anim.SetBool("isLooking", false);
        Rigidbody bulletRb = Instantiate(Bullet,firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * forwardShotForce, ForceMode.Impulse);

       // Destroy(gameObject, 4f);
    }
}
