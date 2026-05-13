
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class FollowPlayerCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    Vector3 velocity = Vector3.zero;
    [Header("Camera Settings")]
    [SerializeField] float smoothTime = 0.3f;
    [Range(0.1f, 1f)]
    [SerializeField] float mouseInfluence = 0.3f;
    Vector3 mousePosition;




    void LateUpdate()
    {
        if (target != null)
        {
            MouseInfluenceCamera();
        }
    }

    void MouseInfluenceCamera()
    {
        Vector2 screenMousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(screenMousePos);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, target.position.y, 0));
        Vector3 mouseWorldPos = target.position;
        if (groundPlane.Raycast(ray, out float enterDistance))
        {
            mouseWorldPos = ray.GetPoint(enterDistance);
        }
        Vector3 targetMidPoint = Vector3.Lerp(target.position, mouseWorldPos, mouseInfluence);
        Vector3 finalTargetPos = targetMidPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, finalTargetPos, ref velocity, smoothTime);

    }
}
