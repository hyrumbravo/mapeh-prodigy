using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button button;        // Reference to the Button
    private static AudioSource persistentAudioSource; // Static AudioSource for persistence

    public AudioClip clickSound; // Reference to the click sound

    void Start()
    {
        // Ensure the persistent AudioSource exists
        if (persistentAudioSource == null)
        {
            CreatePersistentAudioSource();
        }

        // Assign the button click listener
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        // Play the click sound using the persistent AudioSource
        if (persistentAudioSource != null && clickSound != null)
        {
            persistentAudioSource.PlayOneShot(clickSound);
        }
    }

    private void CreatePersistentAudioSource()
    {
        // Create a new GameObject for the persistent AudioSource
        GameObject audioObject = new GameObject("PersistentAudioSource");
        persistentAudioSource = audioObject.AddComponent<AudioSource>();
        
        // Set the AudioSource to persist across scenes
        DontDestroyOnLoad(audioObject);
    }
}
