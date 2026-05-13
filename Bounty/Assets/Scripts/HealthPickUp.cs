using KevinIglesias;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] float healingAmount = 10f;
    [Header("Particle Settings")]
    [SerializeField] GameObject healthParticles;
    [Header("Spin Settings")]
    [SerializeField] float spinSpeed = 100f;

    void OnTriggerEnter(Collider collider)
    {
        PlayerHealth player = collider.GetComponent<PlayerHealth>();
        if (player != null && player.GetPlayerHealth() < 20f)
        {
            player.HealPlayer(healingAmount);
            Instantiate(healthParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
