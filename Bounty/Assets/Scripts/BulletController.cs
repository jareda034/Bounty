using UnityEngine;

public class BulletController : MonoBehaviour
{
   [SerializeField] float bulletSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime, Space.Self);
    }

}
