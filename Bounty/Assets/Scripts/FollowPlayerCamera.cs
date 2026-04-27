using Unity.Cinemachine;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] Vector3 offset;
    Vector3 velocity = Vector3.zero;


    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
