using UnityEngine;

public class FinalObjective : MonoBehaviour
{
   [Header("Reference Settings")]
   BoxCollider box;
   QuestManager questManager;
   Objective5 objective5;

   void Awake()
    {
        box = GetComponent<BoxCollider>();
        questManager = FindAnyObjectByType<QuestManager>();
        objective5 = FindAnyObjectByType<Objective5>();
    }

    void EnableTrigger()
    {
        if (objective5.GetObjectiveDone())
        {
            box.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
      PlayerMovement player = other.GetComponent<PlayerMovement>();

      if (player != null)
        {
            Time.timeScale = 0f;
        }
    }
}
