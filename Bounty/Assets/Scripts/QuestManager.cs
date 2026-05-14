using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    // Variables 

    [SerializeField] private  String[] ObjectivesList;
    private int currentObjectiveIndex = 0;
    bool isObjectiveCompleted = false;
    [Header("UI Settings")]
    [SerializeField] TextMeshProUGUI ObjectiveText;


    void Start()
    {
        if (ObjectivesList.Length > 0)
        {
            StartObjective(ObjectivesList[currentObjectiveIndex]);
        }

    }

    void Update()
    {
        if (isObjectiveCompleted)
        {
            currentObjectiveIndex++;
            if (currentObjectiveIndex < ObjectivesList.Length)
            {
                StartObjective(ObjectivesList[currentObjectiveIndex]);
                isObjectiveCompleted = false;
            }

        }
    } 

    void StartObjective(string objective)
    {
        ObjectiveText.text = objective;
    }

    public void CompleteObjective()
    {
        isObjectiveCompleted = true;
    }

}
