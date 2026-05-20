using UnityEngine;

public class Objective4 : MonoBehaviour
{
  [Header("Reference Settings")]
  [SerializeField] GameObject controlComputer;
  QuestManager questManager;
  PlayerMovementController player;
  Objective5 objective5;
  [Header("Interaction Settings")]
  float playerInteractionRamge = 4f;
  bool playerInRange = false;

  void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();
        questManager = GetComponent<QuestManager>();
        objective5 = GetComponent<Objective5>();
    }

    void Update()
    {
        CheckPlayerRange();
    }

    void CheckPlayerRange()
    {
        if ( Vector3.Distance(controlComputer.transform.position, player.transform.position) <= playerInteractionRamge)
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
        if (playerInRange == true)
        {
            objective5.StartDoorOpening();
            questManager.CompleteObjective();
        }
    }
}
