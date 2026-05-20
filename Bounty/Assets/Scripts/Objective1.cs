using Unity.VisualScripting;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
    QuestManager questManager;
    [Header("Objective Settings")]
    bool hasKeyCard = false;
    [Header("Card Rotation Settings")]
    [SerializeField] float rotationSpeed = 50f;
    [Header("Objective Check Settings")]
    bool objective1Done = false;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
    }

    void Update()
    {
        if (!hasKeyCard)
        {
            SpinKeyCard();
        }
    }

    void SpinKeyCard()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovementController player = other.GetComponent<PlayerMovementController>();
        if (player != null)
        {
            ObjectiveGoal();
            transform.gameObject.SetActive(false);
            hasKeyCard = true;
        }
    }

    void ObjectiveGoal()
    {
        questManager.CompleteObjective();
        objective1Done = true;
    }

    public bool GetObjectiveDone()
    {
        return objective1Done;
    }

    public bool HasKeyCard()
    {
        return hasKeyCard;
    }
}
