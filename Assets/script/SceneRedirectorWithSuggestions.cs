using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneRedirectorWithSuggestions : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to the TMP_InputField
    public GameObject suggestionPanel;  // Panel to hold the suggestions
    public TextMeshProUGUI suggestionPrefab;  // TextPrefab for displaying each suggestion

    // List of scenes to suggest
    private List<string> allSuggestions = new List<string>
    {
        "basketball homepage",
        "scene2",
        "scene3",
        "football scene",
        "volleyball court"
    };

    private List<string> filteredSuggestions = new List<string>();

    void Start()
    {
        // Hide suggestion panel initially
        suggestionPanel.SetActive(false);

        // Listen for input changes
        inputField.onValueChanged.AddListener(OnInputChanged);
    }

    // Called whenever the input text changes
    void OnInputChanged(string inputText)
    {
        filteredSuggestions.Clear();

        // Filter suggestions that match the input text
        foreach (var suggestion in allSuggestions)
        {
            if (suggestion.ToLower().Contains(inputText.ToLower()))
            {
                filteredSuggestions.Add(suggestion);
            }
        }

        // If there are suggestions, show the suggestion panel
        if (filteredSuggestions.Count > 0)
        {
            UpdateSuggestionsDisplay();
            suggestionPanel.SetActive(true);
        }
        else
        {
            suggestionPanel.SetActive(false);
        }
    }

    // Display filtered suggestions
    void UpdateSuggestionsDisplay()
    {
        // Clear previous suggestions
        foreach (Transform child in suggestionPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate and display the filtered suggestions
        foreach (var suggestion in filteredSuggestions)
        {
            TextMeshProUGUI suggestionText = Instantiate(suggestionPrefab, suggestionPanel.transform);
            suggestionText.text = suggestion;

            // Add listener for clicking a suggestion to load the scene
            suggestionText.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => LoadScene(suggestion));
        }
    }

    // Load the corresponding scene
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
