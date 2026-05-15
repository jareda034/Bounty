using UnityEngine;

public class Objective3 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject codeUI;
    QuestManager questManager;
    [Header("Objective Settings")]
    bool isGoalReached = false;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
    }

    void Update()
    {
        if (isGoalReached) { return; }
        CheckIfCodeFound();
    }

    void CheckIfCodeFound()
    {
        if (codeUI != null && codeUI.gameObject.activeSelf)
        {
            GoalComplete();
        }
    }

    void GoalComplete()
    {
        isGoalReached = true;
        questManager.CompleteObjective();
    }
}
