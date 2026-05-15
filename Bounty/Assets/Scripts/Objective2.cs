using UnityEngine;

public class Objective2 : MonoBehaviour
{
    [Header("Reference Settings")]
   [SerializeField] Camera officeSecurityCamera;
   QuestManager questManager;
   [Header("Settings")]
   bool isCameraActive = false;

   void Awake()
    {
        questManager = FindAnyObjectByType<QuestManager>();
    }

    void Update()
    {
        CheckIfCameraActive();
        GoalComplete();
    }

    void CheckIfCameraActive()
    {
        if (officeSecurityCamera != null && officeSecurityCamera.gameObject.activeSelf)
        {
           isCameraActive = true;
        }
        else
        {
            isCameraActive = false;
        }
    }

    void GoalComplete()
    {
        if (isCameraActive)
        {
            questManager.CompleteObjective();
        }
    }

}
