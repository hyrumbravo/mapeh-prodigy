using UnityEngine;
using UnityEngine.UI;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioClip audioClip; // Assign your scene-specific audio clip here
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
            // Pause the audio and update the button image to "Play Image"
            audioSource.Pause();
            if (buttonImage != null)
                buttonImage.sprite = playImage;
                

                
            if (BackgroundMusic.Instance != null)
            {
            // Only resume the background music if it is not muted
                if (!BackgroundMusic.Instance.IsMuted() && BackgroundMusic.Instance.IsPlaying())
                {
                    BackgroundMusic.Instance.SetVolume(1.0f); // Set volume to 100%
                    BackgroundMusic.Instance.ResumeBackgroundMusic();
                }
            }
        }
        else
        {
            // Play the audio and update the button image to "Pause Image"
            audioSource.Play();
            if (buttonImage != null)
                buttonImage.sprite = pauseImage;

            // Lower background music volume to 20% or pause it if muted
            if (BackgroundMusic.Instance != null)
            {
                if (BackgroundMusic.Instance.IsPlaying() && !BackgroundMusic.Instance.IsMuted())
                {
                    BackgroundMusic.Instance.SetVolume(0.2f); // Lower volume to 20%
                }
            }
        }
    }
}
