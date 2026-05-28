using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.AI;

public class SurvivorController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject survivorDialogue;
    PlayerMovementController player;
    NavMeshAgent agent;
    QuestManager questManager;
    Objective3 objective3;
    Animator anim;
    [Header("Dialouge Settings")]
    int interactionRange = 3;
    bool dialogueOpen = false;
    bool inDialogueRange = false;
    bool canFollow = false;
    [Header("Movement Settings")]
    [SerializeField] float speed = 6.5f;
    Transform target;
    int stoppingRange = 4;
    bool stopFollowing = false;
    [Header("Objective Check Settings")]
    bool objectiveTalkDone = false;
    [Header("Ui Settings")]
    [SerializeField] GameObject interactUI;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovementController>();
        agent = GetComponent<NavMeshAgent>();
        questManager = FindAnyObjectByType<QuestManager>();
        anim = GetComponent<Animator>();
        objective3 = FindAnyObjectByType<Objective3>();
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
            interactUI.SetActive(true);
        }
        else
        {
            inDialogueRange = false;
            interactUI.SetActive(false);
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
        if (objective3.GetObjectiveDone())
        {
            questManager.CompleteObjective();
            objectiveTalkDone = true;
        }
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
            anim.SetBool("isMoving", true);
        }
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < stoppingRange)
            {
                stopFollowing = true;
                anim.SetBool("isMoving", false);
            }
            else
            {
                stopFollowing = false;
            }
        }
    }

    public bool IsDialgueOpen()
    {
        return dialogueOpen;
    }

    public bool GetObjectiveDone()
    {
        return objectiveTalkDone;
    }


}
