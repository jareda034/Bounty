using Unity.VisualScripting;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
   QuestManager questManager;
   [Header("Objective Settings")]
   [SerializeField] GameObject keyCard;

    void Awake()
    {
        questManager = GetComponent<QuestManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovementController player = other.GetComponent<PlayerMovementController>();
        if (player != null)
        {
            ObjectiveGoal();
            keyCard.SetActive(false);
        }
    }

    void ObjectiveGoal()
    {
            questManager.CompleteObjective();
        
    } 
}
