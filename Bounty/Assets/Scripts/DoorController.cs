using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
  [Header("References")]
  [SerializeField] GameObject door;
  Objective1 objective1;
  PlayerMovementController player;
  [Header("Settings")]
  [SerializeField] float interactionRange = 3f;
  [Header("Security Door Settings")]
  [SerializeField] bool isSecurityDoor = false;
  bool playerinRange =  false;

  void Awake()
    {
        player = FindFirstObjectByType<PlayerMovementController>();
        objective1 = FindFirstObjectByType<Objective1>();
    }
     

    public void OpenDoor()
    {
        if (isSecurityDoor) { return;}
        if (playerinRange)
        {
            door.SetActive(false);
        }
    }

    void Update()
    {
        CheckPlayerRange();
    }

    void CheckPlayerRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionRange)
        {
            playerinRange = true;
        }
        else
        {
            playerinRange = false;
        }
        
    }

    public void SecurityDoor()
    {
        if ( playerinRange && isSecurityDoor)
        {
            if (objective1.HasKeyCard())
            {
               door.SetActive(false);
            }
        }
    }
}
