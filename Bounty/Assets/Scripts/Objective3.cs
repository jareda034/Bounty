using UnityEngine;

public class Objective3 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] GameObject codeUI;
    QuestManager questManager;
    Objective2 objective2;
    [Header("Objective Settings")]
    bool isGoalReached = false;
    [Header("Objective Check Settings")]
    bool objective3Done = false;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        objective2 = FindAnyObjectByType<Objective2>();
    }

    void Update()
    {
        if (isGoalReached) { return; }
        CheckIfCodeFound();
    }

    void CheckIfCodeFound()
    {
        if (codeUI != null && codeUI.gameObject.activeSelf && objective2.GetObjectiveDone()) 
        {
            GoalComplete();
        }
    }

    void GoalComplete()
    {
        isGoalReached = true;
        questManager.CompleteObjective();
        objective3Done = true;
    }

    public bool GetObjectiveDone()
    {
        return objective3Done;
    }
}
