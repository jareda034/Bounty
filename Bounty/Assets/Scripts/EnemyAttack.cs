using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform firePoint;
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
        Rigidbody bulletRb = Instantiate(Bullet, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>();
        PlayAudio(gunSound,volume);
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position,volume);
    }
}
