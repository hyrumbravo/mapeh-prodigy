using UnityEngine;
using TMPro;
using UnityEngine.UI;  // For accessing the Button and Image components

public class VoiceOverHighlighter : MonoBehaviour
{
    public AudioSource audioSource;        // Audio source for the voice-over

    public Button toggleButton;            // Reference to the button
    public Sprite playButtonSprite;       // Sprite for the play button
    public Sprite pauseButtonSprite;      // Sprite for the pause button
    
    private bool isPaused = false;  // Flag to pause or resume the process


    // Call this method to toggle pause/resume for both audio and highlighting
    public void TogglePausePlay()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the audio and stop highlighting
            audioSource.Pause();
            // Set button to play icon
            toggleButton.image.sprite = playButtonSprite;
        }
        else
        {
            // Resume the audio and highlighting from where it was
            audioSource.Play();
            // Set button to pause icon
            toggleButton.image.sprite = pauseButtonSprite;
        }
    }

    // Method to reset the highlighting and button to initial state
    private void ResetHighlighting()
    {
        isPaused = true;                     // Set to paused
        audioSource.Stop();                  // Stop the audio
        toggleButton.image.sprite = playButtonSprite; // Set button to play icon
    }
}
