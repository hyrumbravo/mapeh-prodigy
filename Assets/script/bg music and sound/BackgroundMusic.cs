using UnityEngine;
public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    private AudioSource audioSource;
    private bool isMuted = false;  // Flag to track if background music is muted

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PauseBackgroundMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void ResumeBackgroundMusic()
    {
        // Check if the background music is muted before resuming
        if (!isMuted && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Set muted state
    public void SetMuted(bool muted)
    {
        isMuted = muted;
        audioSource.mute = muted; // Mute/unmute the audio source
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
