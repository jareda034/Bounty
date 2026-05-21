using UnityEngine;

public class Alarm : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] AudioClip alramSound;
    [Range(0, 1)][SerializeField] float volume;

    void PlayAudio(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    void Update()
    {
        PlayAudio(alramSound, volume);
    } 
}
