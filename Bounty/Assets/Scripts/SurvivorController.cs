using UnityEngine;
using UnityEngine.AI;

public class SurvivorController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject survivorDialogue;
    PlayerMovementController player;
    NavMeshAgent agent;
    [Header("Dialouge Settings")]
    int interactionRange = 3;
    bool dialogueOpen = false;
    bool inDialogueRange = false;
    bool canFollow = false;
    [Header("Movement Settings")]
    [SerializeField] float speed = 5f;
    Transform target;
    int stoppingRange = 2;
    bool stopFollowing = false;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        CheckPlayerRange();
        FollowPlayer();
    }

    void CheckPlayerRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < interactionRange)
        {
            inDialogueRange = true;
        }
        else
        {
            inDialogueRange = false;
        }
    }


    public void OpenDialogue()
    {
        if (inDialogueRange)
        {
            survivorDialogue.gameObject.SetActive(true);
            dialogueOpen = true;
        }
    }

    public void EndDialogue()
    {
        survivorDialogue.gameObject.SetActive(false);
        dialogueOpen = false;
        canFollow = true;
    }

    void FollowPlayer()
    {
        if (canFollow)
        {
            target = player.transform;
        }

        if (target != null && stopFollowing == false)
        {
            agent.SetDestination(target.transform.position);
        }
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < stoppingRange)
            {
                stopFollowing = true;
            }
            else
            {
                stopFollowing = false;
            }
        }
    }
}
