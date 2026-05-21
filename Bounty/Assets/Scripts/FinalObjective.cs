using UnityEngine;

public class FinalObjective : MonoBehaviour
{
   [Header("Reference Settings")]
   [SerializeField] GameObject finalObjectiveBox;
   QuestManager questManager;
   Objective5 objective5;

   void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        objective5 = FindAnyObjectByType<Objective5>();
    }

    void EnableTrigger()
    {
        if (objective5.GetObjectiveDone())
        {
            finalObjectiveBox.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
      PlayerMovementController player = other.GetComponent<PlayerMovementController>();

      if (player != null)
        {
            Time.timeScale = 0f;
        }
    }
}
