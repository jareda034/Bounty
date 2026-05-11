using UnityEngine;

public class AmmoBoxController : MonoBehaviour
{
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
}
