using UnityEngine;

public class FinalObjective : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject finalObjectiveBox;
    QuestManager questManager;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
    }

    public void EnableTrigger()
    {
        finalObjectiveBox.SetActive(true);
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
