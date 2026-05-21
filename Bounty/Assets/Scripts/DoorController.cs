using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class DoorController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject door;
    Objective1 objective1;
    PlayerMovementController player;
    [Header("Settings")]
    [SerializeField] float interactionRange = 3f;
    [Header("Security Door Settings")]
    [SerializeField] bool isSecurityDoor = false;
    bool playerinRange = false;

    [Header("Audio Settings")]
    [SerializeField] AudioClip doorOpeningSound;
    [Range(0, 1)][SerializeField] float volume;

    void Awake()
    {
        player = FindFirstObjectByType<PlayerMovementController>();
        objective1 = FindFirstObjectByType<Objective1>();
    }


    public void OpenDoor()
    {
        if (isSecurityDoor) { return; }
        if (playerinRange)
        {
            door.SetActive(false);
            PlayAudio(doorOpeningSound, volume);
        }
    }

    void Update()
    {
        CheckPlayerRange();
    }

    void CheckPlayerRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionRange)
        {
            playerinRange = true;
        }
        else
        {
            playerinRange = false;
        }
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        if (clip != null)
        {
           AudioSource.PlayClipAtPoint(clip, transform.position, volume); 
        }

    }

    public void SecurityDoor()
    {
        if (playerinRange && isSecurityDoor)
        {
            if (objective1.HasKeyCard())
            {
                door.SetActive(false);
                PlayAudio(doorOpeningSound, volume);
            }
        }
    }
}
