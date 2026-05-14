using Unity.VisualScripting;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
   QuestManager questManager;
   [Header("Objective Settings")]
   [SerializeField] GameObject keyCard;
   bool hasKeyCard = false;
   [Header("Card Rotation Settings")]
   [SerializeField] float rotationSpeed = 50f;

    void Awake()
    {
        questManager = GetComponent<QuestManager>();
    }

    void SpinKeyCard()
    {
        keyCard.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovementController player = other.GetComponent<PlayerMovementController>();
        if (player != null)
        {
            ObjectiveGoal();
            keyCard.SetActive(false);
            hasKeyCard = true;
        }
    }

    void ObjectiveGoal()
    {
            questManager.CompleteObjective();
        
    } 

    public bool HasKeyCard()
    {
        return hasKeyCard;
    }
}
