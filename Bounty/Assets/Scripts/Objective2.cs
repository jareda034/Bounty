using UnityEngine;

public class Objective2 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] Camera officeSecurityCamera;
    QuestManager questManager;
    Objective1 objective1;
    [Header("Settings")]
    bool isGoalReached = false;
    [Header("Objective Check Settings")]
    bool objective2Done = false;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
        objective1 = FindAnyObjectByType<Objective1>();
    }

    void Update()
    {
        if (isGoalReached) { return; }
        CheckIfCameraActive();
    }

    void CheckIfCameraActive()
    {
        if (officeSecurityCamera != null && officeSecurityCamera.gameObject.activeSelf && objective1.GetObjectiveDone())
        {
            GoalComplete();
        }

    }

    void GoalComplete()
    {
        isGoalReached = true;
        questManager.CompleteObjective();
        objective2Done = true;
    }

    public bool GetObjectiveDone()
    {
        return objective2Done;
    }

}
