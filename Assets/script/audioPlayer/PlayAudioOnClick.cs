using UnityEngine;
using UnityEngine.UI;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip here
    public Button button; // Assign your button here
    public Sprite playImage; // Image to display when audio is playing
    public Sprite pauseImage; // Image to display when audio is paused

    private AudioSource audioSource;
    private Image buttonImage;

    void Start()
    {
        // Add an AudioSource component to the GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Get the Image component of the button
        if (button != null)
        {
            buttonImage = button.GetComponent<Image>();

            // Set the initial image
            if (buttonImage != null)
                buttonImage.sprite = playImage;

            // Add a listener to the button
            button.onClick.AddListener(ToggleAudio);
        }
        else
        {
            Debug.LogError("Button is not assigned in the Inspector.");
        }
    }

    // Method to toggle audio and update button image
    void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            // Pause the audio and update the button image to "Pause Image"
            audioSource.Pause();
            if (buttonImage != null)
                buttonImage.sprite = playImage;
        }
        else
        {
            // Play the audio and update the button image to "Play Image"
            audioSource.Play();
            if (buttonImage != null)
                buttonImage.sprite = pauseImage;
        }
    }
}
