using UnityEngine;

public class SceneAudioManager : MonoBehaviour
{
    public AudioSource sceneAudio; // Assign the audio source for this scene

    private void Start()
    {
        if (sceneAudio != null && BackgroundMusic.Instance != null)
        {
            // Pause background music when scene audio starts
            sceneAudio.Play();
            BackgroundMusic.Instance.PauseBackgroundMusic();
        }
    }

    private void Update()
    {
        if (sceneAudio != null && BackgroundMusic.Instance != null)
        {
            // Resume background music when scene audio finishes
            if (!sceneAudio.isPlaying && !BackgroundMusic.Instance.IsPlaying())
            {
                BackgroundMusic.Instance.ResumeBackgroundMusic();
            }
        }
    }
}


