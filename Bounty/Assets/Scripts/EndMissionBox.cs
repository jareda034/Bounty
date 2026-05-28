using UnityEngine;

public class EndMissionBox : MonoBehaviour
{
    [Header("References")]
    MissionOverScreen missionOver;

    void Awake()
    {
        missionOver = FindAnyObjectByType<MissionOverScreen>();
    }
   void OnTriggerEnter(Collider other)
    {
        PlayerMovementController player = other.GetComponent<PlayerMovementController>();

        if (player != null)
        {
            Time.timeScale = 0f;
            missionOver.ShowMissionOver();
        }
    }
}
