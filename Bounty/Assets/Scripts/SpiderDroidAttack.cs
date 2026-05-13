using UnityEngine;

public class SpiderDroidAttack : MonoBehaviour
{

  [Header("Ref")]
  [SerializeField] GameObject Bullet;
  [SerializeField] Transform firePoint1;
  [SerializeField] Transform firePoint2;
  Animator anim;

   void Awake()
    {
        anim = GetComponent<Animator>();
    }

  public void FireBullet()
    {
        anim.SetBool("isLooking", false);
        Rigidbody bulletRb = Instantiate(Bullet, firePoint1.position, firePoint1.rotation).GetComponent<Rigidbody>();
        bulletRb = Instantiate(Bullet, firePoint2.position, firePoint2.rotation).GetComponent<Rigidbody>();

    }
}
