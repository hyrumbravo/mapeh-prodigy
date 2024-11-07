using UnityEngine;
using TMPro;
using UnityEngine.UI;  // For accessing the Button and Image components

public class VoiceOverHighlighter : MonoBehaviour
{
    public AudioSource audioSource;        // Audio source for the voice-over
    public TextMeshProUGUI textComponent;  // Text component displaying the text
    public Button toggleButton;            // Reference to the button
    public Sprite playButtonSprite;       // Sprite for the play button
    public Sprite pauseButtonSprite;      // Sprite for the pause button
    
    private string[] words = { "Basketball", "was", "invented", "in", "December", "1891", "by James Naismith,", "a Canadian", "physical education", "instructor", "at the YMCA", "International", "Training School", "in Springfield,", "Massachusetts.", "Tasked by", "his superior,", "Dr. Luther", "H. Gulick,", "to create", "an indoor game", "that would", "keep young", "men active", "during the", "cold winter", "months,", "Naismith set out", "to design a sport", "that emphasized", "skill", "rather than brute strength.", "Drawing inspiration", "from a childhood game", "called 'Duck on a Rock,'", "Naismith developed", "the basic rules of basketball,", "which involved players", "throwing a ball", "into a raised peach basket.", "The first game was played", "with nine players", "on each team,", "and the sport", "quickly gained popularity."};
    private float[] wordTimestamps = { 1.38f, 1.99f, 2.58f, 2.65f, 2.90f, 3.50f, 4.34f, 5.65f, 6.30f, 7.25f, 7.81f, 9.04f, 9.72f, 11.30f, 11.73f, 13.11f, 13.55f, 15.01f, 15.70f, 16.20f, 17.05f, 17.44f, 18.15f, 18.53f, 19.09f, 19.67f, 20.17F, 22.20f, 23.01f, 24.50f, 25.25f, 26.50f };
    private int currentWordIndex = 0;
    private bool isPaused = false;  // Flag to pause or resume the process

    private void Update()
    {
        // Only update if not paused
        if (!isPaused && currentWordIndex < words.Length && audioSource.time >= wordTimestamps[currentWordIndex])
        {
            HighlightWord(currentWordIndex);
            currentWordIndex++;
        }
    }

    private void HighlightWord(int index)
    {
        // Rebuild the text with the current word highlighted
        string highlightedText = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (i == index)
                highlightedText += $"<color=#429EBD>{words[i]}</color> "; // Hex color for highlighting
            else
                highlightedText += $"{words[i]} ";
        }
        textComponent.text = highlightedText;
    }

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
}
