using Unity.VisualScripting;
using UnityEngine;

public class Objective5 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject bayDoor;
    QuestManager questManager;
    [Header("Door Opening Settings")]
    [SerializeField] float openingSpeed = 0.5f;
    [SerializeField] float maxDistance = 3.9f;
    bool canDoorOpen = false;
    [Header("Objective Check Settings")]
    bool objective5Done = false;

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
        if (bayDoor.transform.position.y >= maxDistance)
        {
            Vector3 finalPos = bayDoor.transform.position;
            finalPos.y = maxDistance;
            bayDoor.transform.position = finalPos;
            canDoorOpen = false;
            objective5Done = true;
        }
    }

    public bool GetObjectiveDone()
    {
        return objective5Done;
    }
}
