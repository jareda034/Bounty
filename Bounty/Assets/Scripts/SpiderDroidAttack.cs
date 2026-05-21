using UnityEngine;

public class SpiderDroidAttack : MonoBehaviour
{

    [Header("Ref")]
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    Animator anim;
    [Header("Audio Settings")]
    [SerializeField] AudioClip gunSound;
    [Range(0, 1)][SerializeField] float volume;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void FireBullet()
    {
        anim.SetBool("isLooking", false);
        Rigidbody bulletRb = Instantiate(Bullet, firePoint1.position, firePoint1.rotation).GetComponent<Rigidbody>();
        bulletRb = Instantiate(Bullet, firePoint2.position, firePoint2.rotation).GetComponent<Rigidbody>();
        PlayAudio(gunSound, volume);
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position,volume);
    }
}
