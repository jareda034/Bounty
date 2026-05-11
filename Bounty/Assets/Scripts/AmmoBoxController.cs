using UnityEngine;

public class AmmoBoxController : MonoBehaviour
{
    [Header("Box Spin Settings")]
    [SerializeField] float spinSpeed = 50f;

   int ammoAmount = 15;

   void OnTriggerEnter(Collider collider)
    {
        PlayerWeapon player = collider.GetComponent<PlayerWeapon>();
        if (player != null)
        {
            player.AddAmmo(ammoAmount);
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
