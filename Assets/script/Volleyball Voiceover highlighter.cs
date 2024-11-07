using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolleyballVoiceoverhighlighter : MonoBehaviour
{
    public AudioSource audioSource;          // Audio source for the voice-over
    public TextMeshProUGUI textComponent;    // Text component displaying the text
    public Button toggleButton;              // Reference to the play/pause button
    public Sprite playButtonSprite;          // Sprite for the play button
    public Sprite pauseButtonSprite;         // Sprite for the pause button

    private string[] words = {
        "Volleyball", "originated", "in the United States", "in 1895", "when William G. Morgan",
        "a physical", "education director", "at the YMCA", "in Holyoke, Massachusetts,", "created the game",
        "as a less", "physically demanding", "alternative to basketball.", "Initially called",
        "mintonette,", "the game", "combined elements", "from tennis,", "basketball,", "and handball.",
        "The name", "was changed to", "volleyball", "following a", "demonstration game",
        "where a spectator", "noted that", "the players", "were volleying", "the ball",
        "back and forth", "over the net.", "The sport", "quickly grew", "in popularity", "and",
        "spread internationally.", "By 1947,", "the Fédération", "Internationale", "de Volleyball",
        "(FIVB) was established", "to govern the sport,", "and the first", "World Championships",
        "took place in 1949.", "Volleyball was introduced", "as an Olympic", "sport in 1964",
        "at the Tokyo Games,", "cementing its status as a global phenomenon."
    };

    // Replace with actual timestamps (in seconds) for each word based on the audio
    private float[] wordTimestamps = { 
        0.5f, 1.0f, 2.0f, 2.7f, 3.5f, 4.3f, 5.0f, 5.8f, 6.7f, 7.5f, 
        8.2f, 9.0f, 9.8f, 10.5f, 11.2f, 12.0f, 12.8f, 13.5f, 14.3f, 15.0f,
        15.8f, 16.5f, 17.3f, 18.0f, 18.8f, 19.5f, 20.2f, 21.0f, 21.8f, 22.5f,
        23.2f, 24.0f, 24.8f, 25.5f, 26.3f, 27.0f, 27.8f, 28.5f, 29.3f, 30.0f,
        30.8f, 31.5f, 32.2f, 33.0f, 33.8f, 34.5f, 35.3f, 36.0f, 36.8f, 37.5f
    };

    private int currentWordIndex = 0;
    private bool isPaused = false;

    private void Update()
    {
        if (!isPaused && currentWordIndex < words.Length)
        {
            // Check if the audio has reached the timestamp for the current word
            if (audioSource.time >= wordTimestamps[currentWordIndex])
            {
                HighlightWord(currentWordIndex);
                currentWordIndex++;
            }
        }
    }

    private void HighlightWord(int index)
    {
        // Rebuild the text with the current word highlighted
        string highlightedText = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (i == index)
                highlightedText += $"<color=#429EBD>{words[i]}</color> ";
            else
                highlightedText += $"{words[i]} ";
        }
        textComponent.text = highlightedText;
    }

    public void TogglePausePlay()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            audioSource.Pause();
            toggleButton.image.sprite = playButtonSprite;
        }
        else
        {
            audioSource.Play();
            toggleButton.image.sprite = pauseButtonSprite;
        }
    }
}