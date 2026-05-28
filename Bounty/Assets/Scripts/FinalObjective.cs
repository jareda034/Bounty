using UnityEngine;

public class FinalObjective : MonoBehaviour
{
    [Header("Reference Settings")]
    QuestManager questManager;
    Objective5 objective5;
    [SerializeField] GameObject finalBox;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        objective5 = FindAnyObjectByType<Objective5>();
    }

    void Update()
    {
        EnableTrigger();
    }

    void EnableTrigger()
    {
        if (objective5.GetObjectiveDone())
        {
          finalBox.SetActive(true);  
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
