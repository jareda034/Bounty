using Unity.VisualScripting;
using UnityEngine;

public class Objective5 : MonoBehaviour
{
 [Header("Reference Settings")]
 [SerializeField] GameObject bayDoor;
 QuestManager questManager;
 [Header("Door Opening Settings")]
 [SerializeField] float openingSpeed = 0.5f;
 bool canDoorOpen = false;

 void Awake()
    {
        questManager = GetComponent<QuestManager>();
    }

    void Update()
    {
        OpeningDoor();
    }

    public void StartDoorOpening()
    {
       canDoorOpen = true;
    }

    void OpeningDoor()
    {
        if (canDoorOpen)
        {
            bayDoor.transform.Translate(Vector3.up * openingSpeed * Time.deltaTime);
        }
    }

    void StopMoving()
    {
        if(bayDoor.transform.position.y == 3.9)
        {
            canDoorOpen = false;
        }
    }
}
