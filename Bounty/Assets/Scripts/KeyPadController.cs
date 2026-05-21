using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using Mono.Cecil.Cil;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
    [SerializeField] TMP_Text passwordText;
    [Header("Code Settings")]
    [SerializeField] string passWord = "12234";
    string playerInputs = "";
    bool passWordIsSame = false;

    [Header("Audio Settings")]
    [SerializeField] AudioClip doorOpeningSound;
    [Range(0, 1)][SerializeField] float volume;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();

    }

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
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

    public void ButtonValue(string value)
    {
        if (playerInputs.Length < passWord.Length)
        {
            playerInputs += value;
            UpdatePassword();
        }
    }

    public void ClearPassword()
    {
        playerInputs = "";
        UpdatePassword();
    }

    void UpdatePassword()
    {
        passwordText.text = playerInputs;
    }

    public void EnterPassword()
    {
        CheckPassword();
    }

    void CheckPassword()
    {
        if (playerInputs == passWord)
        {
            securityDoor.gameObject.SetActive(false);
            keyPadUI.SetActive(false);
            keyPadUIOpen = false;
            PlayAudio(doorOpeningSound, volume);
        }
    }

}
