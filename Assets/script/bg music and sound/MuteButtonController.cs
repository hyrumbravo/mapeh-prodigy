using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public Sprite muteIcon;    // Assign the mute icon in the Inspector
    public Sprite unmuteIcon;  // Assign the unmute icon in the Inspector
    public Image buttonImage;  // Assign the button's Image component

    private void Start()
    {
        UpdateIcon(); // Set the initial icon based on the audio state
    }

    public void TogglePlayPause()
    {
        if (BackgroundMusic.Instance != null)
        {
            AudioSource audioSource = BackgroundMusic.Instance.GetComponent<AudioSource>();

            if (audioSource.isPlaying)
            {
                audioSource.Pause(); // Pause the audio
            }
            else
            {
                audioSource.Play(); // Play the audio
            }

            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        if (BackgroundMusic.Instance != null)
        {
            AudioSource audioSource = BackgroundMusic.Instance.GetComponent<AudioSource>();

            // Update the icon based on whether the audio is playing
            buttonImage.sprite = audioSource.isPlaying ? unmuteIcon : muteIcon;
        }
    }
}
