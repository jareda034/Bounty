using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
  [Header("Ref")]
  [SerializeField] GameObject Bullet;
  [SerializeField] Transform firePoint;
  Animator anim;

   void Awake()
    {
        anim = GetComponent<Animator>();
    }

  public void FireBullet()
    {
        anim.SetBool("isLooking", false);
        Rigidbody bulletRb = Instantiate(Bullet, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>();

    }
}
