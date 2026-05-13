using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
  [Header("References")]
  [SerializeField] GameObject door;
  PlayerMovementController player;
  [Header("Settings")]
  [SerializeField] float interactionRange = 3f;
  bool playerinRange =  false;

  void Awake()
    {
        player = FindFirstObjectByType<PlayerMovementController>();
    }
     

    public void OpenDoor()
    {
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
}
