using System.Collections.Generic;
using UnityEngine;

public class HideWalls : MonoBehaviour
{
 [SerializeField] Transform player;
 [SerializeField] LayerMask wallLayer;
 float hideFadDuration = 0.5f;

 private List<GameObject> hiddenWalls = new List<GameObject>();

    void LateUpdate()
    {
        HideWallFromView();
    }

    void HideWallFromView()
    {
        foreach (var wall in hiddenWalls)
        {
            wall.SetActive(true);
        }

        hiddenWalls.Clear();

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction.normalized, distance, wallLayer);
       
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Object hit");
                GameObject hitWall = hit.collider.gameObject;
                hitWall.SetActive(false);
                hiddenWalls.Add(hitWall);
            }
        
       }
    }
}
