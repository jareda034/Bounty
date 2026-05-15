using System.ComponentModel.Design;
using UnityEngine;

public class KeyPadController : MonoBehaviour
{
    [Header("Refernece Settings")]
    PlayerMovementController player;
    [SerializeField] GameObject securityDoor;
    [SerializeField] GameObject keyPadUI;
    [Header("Interaction Settings")]
    [SerializeField] float interactionRange;
    bool isPlayerInRange = false;
    [Header("UI Settings")]
    bool keyPadUIOpen = false;


    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();

    }

    void Update()
    {
        CheckPlayerInRange();
    }

    void CheckPlayerInRange()
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

    public void OpenKeyPad()
    {
        if (isPlayerInRange)
        {
            keyPadUI.SetActive(true);
            keyPadUIOpen = true;
        }
    }

    public void CloseKeyPad()
    {
        keyPadUI.SetActive(false);
        keyPadUIOpen = false;
    }

    public bool KeyPadOpen()
    {
        return keyPadUIOpen;
    }

}
