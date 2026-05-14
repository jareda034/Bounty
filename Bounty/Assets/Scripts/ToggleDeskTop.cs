using System;
using UnityEngine;

public class ToggleDeskTop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject DeskTopUI;
    PlayerMovementController player;
    [Header("Interaction Settings")]
    [SerializeField] float interactionRange = 3f;
    bool isPlayerInRange = false;
    bool isUIOpen = false;


    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();
    }

    void Update()
    {
        CheckRange();
    }

    void CheckRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionRange)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    public void ToggleUI()
    {
        if (isPlayerInRange)
        {
            DeskTopUI.SetActive(true);
            isUIOpen = true;
        }

    }

    public void CloseUI()
    {
        DeskTopUI.SetActive(false);
        isUIOpen = false;
    }

    public bool IsUIOpen()
    {
        return isUIOpen;
    }
}
