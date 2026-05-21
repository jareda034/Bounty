using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    // Variables 

    [Header("Objective Settings")]
    [SerializeField] private  String[] ObjectivesList;
    private int currentObjectiveIndex = 0;
    bool isObjectiveCompleted = false;
    [Header("UI Settings")]
    [SerializeField] TextMeshProUGUI ObjectiveText;

    void Awake()
    {
        ObjectiveText.color = Color.white;
    }


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
        Invoke(nameof(ChangeColor), 1f);
        ObjectiveText.color = Color.yellow;
    }

    void ChangeColor()
    {
        ObjectiveText.color = Color.green;
    }

    public void CompleteObjective()
    {
        isObjectiveCompleted = true;
    }

}
