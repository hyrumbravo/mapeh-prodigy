using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    public Sprite faveImage; // The image when it's favorited (Fave)
    public Sprite unfaveImage;  // The image when it's not favorited (Unfave)
    private Image imageComponent; // Reference to the Image component

    private string key; // Unique key for each button's favorite status

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Prevent this GameObject from being destroyed when changing scenes
    }

    private void Start()
    {
        // Get the Image component on the same GameObject
        imageComponent = GetComponent<Image>();

        // Generate a unique key for each button based on its name or instance ID
        key = "faveStatus_" + gameObject.name; // Using the name of the GameObject as part of the key

        // Load the saved favorite status for this button
        LoadFavoriteStatus();
    }

    // This method will be called when the Image is clicked
    public void OnImageClicked()
    {
        // Check if the current image is the unfavorite image
        if (imageComponent.sprite == unfaveImage)
        {
            // Change to the favorite image
            imageComponent.sprite = faveImage;
            // Save the favorite status for this specific button
            PlayerPrefs.SetInt(key, 1); // 1 represents "fave"
        }
        else
        {
            // Revert back to the unfavorite image
            imageComponent.sprite = unfaveImage;
            // Save the unfavorite status for this specific button
            PlayerPrefs.SetInt(key, 0); // 0 represents "unfave"
        }

        // Save the preferences immediately
        PlayerPrefs.Save();  // Ensures data is saved
    }

    // Method to load the favorite status from PlayerPrefs
    private void LoadFavoriteStatus()
    {
        // Check if the favorite status exists for this button in PlayerPrefs
        if (PlayerPrefs.HasKey(key))
        {
            int status = PlayerPrefs.GetInt(key);
            // Set the image based on the saved status for this button
            if (status == 1)
            {
                imageComponent.sprite = faveImage; // Set to favorite
            }
            else
            {
                imageComponent.sprite = unfaveImage; // Set to unfavorite
            }
        }
        else
        {
            // If no status is saved, set the image to unfavorite by default
            imageComponent.sprite = unfaveImage;
        }
    }
}
