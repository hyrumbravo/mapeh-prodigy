using UnityEngine;
using TMPro;  // Import the TextMesh Pro namespace
using System.Collections.Generic;
using UnityEngine.SceneManagement;  // For loading scenes

public class InputFieldDropdownSuggestion : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to TMP_InputField
    public TMP_Dropdown suggestionDropdown;  // Reference to TMP_Dropdown for suggestions
    public List<string> suggestions = new List<string>();  // List of suggestion options
    private List<string> filteredSuggestions = new List<string>();  // Filtered suggestions for the dropdown

    void Start()
    {
        // Populate suggestions (this can be customized or loaded dynamically)
        suggestions.Add("Appled");
        suggestions.Add("Banana");
        suggestions.Add("Orange");
        suggestions.Add("Mango");
        suggestions.Add("Avocado");
        suggestions.Add("basketball homepage");
        suggestions.Add("basketball skills");
        suggestions.Add("basketball homesick");
        suggestions.Add("Apricot");

        // Add listener for input change
        inputField.onValueChanged.AddListener(OnInputChanged);

        // Initially hide the dropdown
        suggestionDropdown.gameObject.SetActive(false);

        // Add listener to handle dropdown selection
        suggestionDropdown.onValueChanged.AddListener(OnDropdownSelectionChanged);
    }

    public void OnInputChanged(string input)
    {
        // Filter the suggestions based on input (case insensitive matching)
        filteredSuggestions = suggestions.FindAll(s => s.ToLower().Contains(input.ToLower()));

        // Update dropdown options with the filtered suggestions
        suggestionDropdown.ClearOptions();
        suggestionDropdown.AddOptions(filteredSuggestions);

        // Show the dropdown only if there are matching suggestions
        suggestionDropdown.gameObject.SetActive(filteredSuggestions.Count > 0);
    }

    public void OnDropdownSelectionChanged(int index)
    {
        // Check if a valid index is selected
        if (index >= 0 && index < filteredSuggestions.Count)
        {
            string selectedSuggestion = filteredSuggestions[index];

            // Handle scene redirection based on the selected suggestion
            // Make sure the scene names match exactly with the options in the dropdown
            if (selectedSuggestion == "basketball homepage")
            {
                SceneManager.LoadScene("Basketball homepage");  // Make sure this scene name is correct in your project
            }
            else if (selectedSuggestion == "basketball skills")
            {
                SceneManager.LoadScene("BasketballSkills");  // Ensure this matches the exact scene name
            }
            else if (selectedSuggestion == "basketball homesick")
            {
                SceneManager.LoadScene("BasketballHomesick");  // Ensure this matches the exact scene name
            }
            else if (selectedSuggestion == "Appled")
            {
                SceneManager.LoadScene("AppleScene");  // Ensure this matches the exact scene name
            }
            // Add more conditions for other options if necessary

            // Disable the dropdown after a selection is made (hide the dropdown)
            suggestionDropdown.gameObject.SetActive(false);
        }
    }
}
