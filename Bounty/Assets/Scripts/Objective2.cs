using UnityEngine;

public class Objective2 : MonoBehaviour
{
    [Header("Reference Settings")]
    [SerializeField] Camera officeSecurityCamera;
    QuestManager questManager;
    [Header("Settings")]
    bool isGoalReached = false;

    void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
    }

    void Update()
    {
        if (isGoalReached) { return; }
        CheckIfCameraActive();
    }

    void CheckIfCameraActive()
    {
        if (officeSecurityCamera != null && officeSecurityCamera.gameObject.activeSelf)
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
