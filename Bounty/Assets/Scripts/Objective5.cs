using Unity.VisualScripting;
using UnityEngine;

public class Objective5 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject bayDoor;
    [SerializeField] Light doorLight;
    QuestManager questManager;
    FinalObjective finalObjective;
    [Header("Door Opening Settings")]
    [SerializeField] float openingSpeed = 0.5f;
    [SerializeField] float maxDistance = 3.9f;
    [Header("Light Settings")]
    [SerializeField] Color color;
    bool canDoorOpen = false;
    void Awake()
    {
        questManager = GetComponent<QuestManager>();
        finalObjective = FindAnyObjectByType<FinalObjective>();
        doorLight.color = Color.red;
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
            finalObjective.EnableTrigger();
            doorLight.color = new Color(0.087f, 0.736f, 1.0f);
        }
    }
}
