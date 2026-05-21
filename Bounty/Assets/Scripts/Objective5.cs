using Unity.VisualScripting;
using UnityEngine;

public class Objective5 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject bayDoor;
    [SerializeField] Light doorLight;
    QuestManager questManager;
    Objective4 objective4;
    [Header("Door Opening Settings")]
    [SerializeField] float openingSpeed = 0.5f;
    [SerializeField] float maxDistance = 3.9f;
    [Header("Light Settings")]
    [SerializeField] Color color;
    bool canDoorOpen = false;
    [Header("Objective Check Settings")]
    bool objective5Done = false;
    void Awake()
    {
        questManager = GetComponent<QuestManager>();
        objective4 = GetComponent<Objective4>();
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
        if (canDoorOpen && objective4.GetObjectiveDone())
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
            doorLight.color = new Color(0.087f, 0.736f, 1.0f);
        }
    }

    public bool GetObjectiveDone()
    {
        return objective5Done;
    }
}
