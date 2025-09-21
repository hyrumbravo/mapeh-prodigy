// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Video;

// public class VideoController : MonoBehaviour
// {
//     public VideoPlayer videoPlayer; // Assign your VideoPlayer component here
//     public Button playPauseButton; // Assign your play/pause button here
//     public Button stopButton; // Assign your stop button here
//     public Sprite playImage; // Image to display when video is not playing
//     public Sprite pauseImage; // Image to display when video is playing

//     private Image playPauseButtonImage;

//     void Start()
//     {
//         // Setup play/pause button
//         if (playPauseButton != null)
//         {
//             playPauseButtonImage = playPauseButton.GetComponent<Image>();

//             // Set the initial button image
//             if (playPauseButtonImage != null)
//                 playPauseButtonImage.sprite = playImage;

//             // Add a listener to the play/pause button
//             playPauseButton.onClick.AddListener(ToggleVideo);
//         }
//         else
//         {
//             Debug.LogError("Play/Pause Button is not assigned in the Inspector.");
//         }

//         // Setup stop button
//         if (stopButton != null)
//         {
//             stopButton.onClick.AddListener(StopVideo);
//         }
//         else
//         {
//             Debug.LogError("Stop Button is not assigned in the Inspector.");
//         }

//         // Ensure the VideoPlayer is prepared
//         if (videoPlayer != null)
//         {
//             videoPlayer.playOnAwake = false; // Do not autoplay on start
//             videoPlayer.isLooping = false; // Optional: Set looping if needed
//         }
//         else
//         {
//             Debug.LogError("VideoPlayer is not assigned in the Inspector.");
//         }
//     }

//     // Method to toggle video playback and update button image
//     void ToggleVideo()
//     {
//         if (videoPlayer == null)
//         {
//             Debug.LogError("VideoPlayer is not assigned.");
//             return;
//         }

//         if (videoPlayer.isPlaying)
//         {
//             // Pause the video and update the button image to "Play Image"
//             videoPlayer.Pause();
//             if (playPauseButtonImage != null)
//                 playPauseButtonImage.sprite = playImage;
//         }
//         else
//         {
//             // Play the video and update the button image to "Pause Image"
//             videoPlayer.Play();
//             if (playPauseButtonImage != null)
//                 playPauseButtonImage.sprite = pauseImage;
//         }
//     }

//     // Method to stop video and reset play/pause button to "Play Image"
//     void StopVideo()
//     {
//         if (videoPlayer == null)
//         {
//             Debug.LogError("VideoPlayer is not assigned.");
//             return;
//         }

//         // Stop the video
//         videoPlayer.Stop();

//         // Reset the play/pause button image to "Play Image"
//         if (playPauseButtonImage != null)
//             playPauseButtonImage.sprite = playImage;
//     }
// }


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Assign your VideoPlayer component here
    public Button playPauseButton; // Assign your play/pause button here
    public Button stopButton; // Assign your stop button here
    public Sprite playImage; // Image to display when video is not playing
    public Sprite pauseImage; // Image to display when video is playing

    private Image playPauseButtonImage;

    void Start()
    {
        // Setup play/pause button
        if (playPauseButton != null)
        {
            playPauseButtonImage = playPauseButton.GetComponent<Image>();

            // Set the initial button image
            if (playPauseButtonImage != null)
                playPauseButtonImage.sprite = playImage;

            // Add a listener to the play/pause button
            playPauseButton.onClick.AddListener(ToggleVideo);
        }
        else
        {
            Debug.LogError("Play/Pause Button is not assigned in the Inspector.");
        }

        // Setup stop button
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopVideo);
        }
        else
        {
            Debug.LogError("Stop Button is not assigned in the Inspector.");
        }

        // Ensure the VideoPlayer is prepared
        if (videoPlayer != null)
        {
            videoPlayer.playOnAwake = false; // Do not autoplay on start
            videoPlayer.isLooping = false; // Optional: Set looping if needed
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned in the Inspector.");
        }
    }

    // Method to toggle video playback and update button image
    void ToggleVideo()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer is not assigned.");
            return;
        }

        if (videoPlayer.isPlaying)
        {
            // Pause the video and update the button image to "Play Image"
            videoPlayer.Pause();
            if (playPauseButtonImage != null)
                playPauseButtonImage.sprite = playImage;

            // Restore background music if not muted
            if (BackgroundMusic.Instance != null)
            {
                if (!BackgroundMusic.Instance.IsMuted() && BackgroundMusic.Instance.IsPlaying())
                {
                    BackgroundMusic.Instance.SetVolume(1.0f); // Full volume
                    BackgroundMusic.Instance.ResumeBackgroundMusic();
                }
            }
        }
        else
        {
            // Play the video and update the button image to "Pause Image"
            videoPlayer.Play();
            if (playPauseButtonImage != null)
                playPauseButtonImage.sprite = pauseImage;

            // Lower background music volume if it's playing and not muted
            if (BackgroundMusic.Instance != null)
            {
                if (BackgroundMusic.Instance.IsPlaying() && !BackgroundMusic.Instance.IsMuted())
                {
                    BackgroundMusic.Instance.SetVolume(0.01f); // Lower volume to 1%
                }
            }
        }
    }

    // Method to stop video and reset play/pause button to "Play Image"
    void StopVideo()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer is not assigned.");
            return;
        }

        // Stop the video
        videoPlayer.Stop();

        // Reset the play/pause button image to "Play Image"
        if (playPauseButtonImage != null)
            playPauseButtonImage.sprite = playImage;

        // Restore background music if not muted
        if (BackgroundMusic.Instance != null)
        {
            if (!BackgroundMusic.Instance.IsMuted() && BackgroundMusic.Instance.IsPlaying())
            {
                BackgroundMusic.Instance.SetVolume(1.0f); // Full volume
                BackgroundMusic.Instance.ResumeBackgroundMusic();
            }
        }
    }
}
