using UnityEngine;

public class Objective4 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject controlComputer;
    QuestManager questManager;
    PlayerMovementController player;
    Objective5 objective5;
    SurvivorController survivorController;
    [Header("Interaction Settings")]
    float playerInteractionRamge = 4f;
    bool playerInRange = false;
    [Header("Objective Check Settings")]
    bool objective4Done = false;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();
        questManager = GetComponent<QuestManager>();
        objective5 = GetComponent<Objective5>();
        survivorController = FindAnyObjectByType<SurvivorController>();
    }

    void Update()
    {
        CheckPlayerRange();
    }

    void CheckPlayerRange()
    {
        if (Vector3.Distance(controlComputer.transform.position, player.transform.position) <= playerInteractionRamge)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    public void UseComputer()
    {
        if (playerInRange == true && survivorController.GetObjectiveDone())
        {
            objective5.StartDoorOpening();
            questManager.CompleteObjective();
            objective4Done = true;
        }
    }
}
