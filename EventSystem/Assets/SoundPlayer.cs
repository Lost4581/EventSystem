using UnityEngine;

public class SoundPlayer : MonoBehaviour, IGameEventListener
{
    [Header("Event References")]
    [SerializeField] private ResourceEvent onResourceChangedEvent;
    [SerializeField] private ResetEvent onResetEvent;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip addSound;
    [SerializeField] private AudioClip removeSound;
    [SerializeField] private AudioClip resetSound;
    [SerializeField] private AudioClip errorSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        if (onResourceChangedEvent != null)
            onResourceChangedEvent.RegisterListener(this);

        if (onResetEvent != null)
            onResetEvent.RegisterListener(this);
    }

    void OnDestroy()
    {
        if (onResourceChangedEvent != null)
            onResourceChangedEvent.UnregisterListener(this);

        if (onResetEvent != null)
            onResetEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        if (onResourceChangedEvent != null)
        {
            PlayResourceSound(onResourceChangedEvent.isAdded);
        }

        if (onResetEvent != null)
        {
            PlayResetSound();
        }
    }

    private void PlayResourceSound(bool isAdded)
    {
        if (isAdded && addSound != null)
        {
            audioSource.PlayOneShot(addSound);
        }
        else if (!isAdded && removeSound != null)
        {
            audioSource.PlayOneShot(removeSound);
        }
    }

    private void PlayResetSound()
    {
        if (resetSound != null)
        {
            audioSource.PlayOneShot(resetSound);
        }
    }
}