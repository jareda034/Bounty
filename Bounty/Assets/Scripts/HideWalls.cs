using System.Collections.Generic;
using UnityEngine;

public class HideWalls : MonoBehaviour
{
 [Header("Reference Settings")]
 [SerializeField] Transform player;
 [SerializeField] LayerMask wallLayer;
 [SerializeField] Material Clear;
 [SerializeField] Material wallMat;

 [Header("Fade Settings")]
 [SerializeField] float hideFadDuration = 0.5f;

 [Header("List Settings")]
 private List<GameObject> hiddenWalls = new List<GameObject>();

    void LateUpdate()
    {
        HideWallFromView();
    }

    void HideWallFromView()
    {
        foreach (var wall in hiddenWalls)
        {
            ChangeWallMaterial(wall, wallMat);
        }

        hiddenWalls.Clear();

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction.normalized, distance, wallLayer);
       
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                GameObject hitWall = hit.collider.gameObject;
                ChangeWallMaterial(hitWall, Clear);
                hiddenWalls.Add(hitWall);
            }
        
       }
    }

    void ChangeWallMaterial(GameObject wall, Material mat)
    {
        Renderer wallRenderer = wall.GetComponent<Renderer>();
        if (wallRenderer != null)
        {
            wallRenderer.material = mat;
        }
    }


}
