using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SceneRedirector : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to the TMP_InputField
    public GameObject suggestionContainer;  // Parent container for suggestion buttons
    public GameObject suggestionButtonPrefab;  // Prefab for suggestion buttons

    // Dictionary to map input words to scene names
    private Dictionary<string, string> sceneMap = new Dictionary<string, string>()
    {
        //ballgames,racketgames,boardgames
        { "ball games", "Ballgames" },

        //basketball
        { "basketball", "Basketball homepage" },

        //basketball intro
        { "basketball introduction", "bball intro" },
        { "basketball history", "bball intro" },

        //basketball faci/equip
        { "basketball court", "faci(court)bball" },
        { "basketball ball", "faci(3dball)bball" },
        { "basketball ring and board", "faci(ringboard)bball" },

        //basketball defensive rule
        { "defensive rule", "bball defensiverules" },

        //basketball offensive rule
        { "offensive rule", "bball offensiverules" },

        //basketball foul
        { "personal Foul", "rule1 foul bball" },
        { "technical Foul", "rule2 foul bball" },
        { "flagrant Foul", "rule3 foul bball" },
        { "looseball foul", "rule1 foul bball" },

        //basketball non foul
        { "travelling", "rule1 nonfoul bball" },
        { "double dribble", "rule2 nonfoul bball" },
        { "back court", "rule3 nonfoul bball" },
        { "carrying", "rule4 nonfoul bball" },
        { "lane violation", "rule4 nonfoul bball" },
        { "kicking", "rule5 nonfoul bball" },
        { "goal tending", "rule6 nonfoul bball" },
        { "out of bounds", "rule7 nonfoul bball" },

        //basketball skills
        { "dribbling (basketball)", "dribbling bball" },
        { "passing (basketball)", "passing bball" },
        { "rebounding (basketball)", "rebound bball" },
        { "shooting (basketball)", "shooting bball" },

        //basketball skills
        { "basketball glossary and terms", "bball glossary and terms" },

        //basketball skills
        { "virtual court(basketball)", "VirtualCourt(bball)" },
        
        

        




















        // Add more words and corresponding scenes here
    };

    void Start()
    {
        // Set up listeners and hide suggestion container initially
        inputField.onValueChanged.AddListener(OnInputChanged);
        inputField.onEndEdit.AddListener(OnInputEndEdit);
        suggestionContainer.SetActive(false);
    }

    void Update()
    {
        // Check if Enter key is pressed while input field is focused
        if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused)
        {
            OnInputEndEdit(inputField.text);  // Trigger scene redirection
        }
    }

    // This function is called as the user types
    public void OnInputChanged(string inputText)
    {
        // Clear existing suggestions
        foreach (Transform child in suggestionContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Show suggestions if input is not empty
        if (!string.IsNullOrEmpty(inputText))
        {
            List<string> suggestions = GetSuggestions(inputText);
            if (suggestions.Count > 0)
            {
                suggestionContainer.SetActive(true); // Show suggestion container

                foreach (string suggestion in suggestions)
                {
                    // Create a button for each suggestion
                    GameObject buttonObject = Instantiate(suggestionButtonPrefab, suggestionContainer.transform);
                    TMP_Text buttonText = buttonObject.GetComponentInChildren<TMP_Text>();
                    buttonText.text = suggestion;

                    // Add a listener to handle button clicks
                    Button button = buttonObject.GetComponent<Button>();
                    button.onClick.AddListener(() => OnSuggestionClicked(suggestion));
                }
            }
            else
            {
                suggestionContainer.SetActive(false); // Hide suggestions if no matches
            }
        }
        else
        {
            suggestionContainer.SetActive(false); // Hide suggestions if input is empty
        }
    }

    // This function is called when a suggestion is clicked
    public void OnSuggestionClicked(string suggestion)
    {
        if (sceneMap.ContainsKey(suggestion.ToLower()))
        {
            string sceneName = sceneMap[suggestion.ToLower()];
            Debug.Log("Redirecting to scene: " + sceneName);
            SceneManager.LoadScene(sceneName);  // Redirect to the corresponding scene
        }
        else
        {
            Debug.Log("Scene not found for suggestion: " + suggestion);
        }
    }

    // This function is called when the Enter key is pressed
    public void OnInputEndEdit(string inputText)
    {
        // Normalize input text: trim spaces and convert to lowercase
        inputText = inputText.Trim().ToLower();
        Debug.Log("User input (normalized): " + inputText);

        // Check if input matches a scene
        if (sceneMap.ContainsKey(inputText))
        {
            string sceneName = sceneMap[inputText];
            Debug.Log("Redirecting to scene: " + sceneName);
            SceneManager.LoadScene(sceneName);  // Load the corresponding scene
        }
        else
        {
            Debug.Log("Scene not found for input: " + inputText);
        }
    }

    // This function provides a list of suggestions based on user input
    List<string> GetSuggestions(string inputText)
    {
        List<string> suggestions = new List<string>();
        foreach (var entry in sceneMap)
        {
            if (entry.Key.ToLower().Contains(inputText.ToLower()))  // Case-insensitive matching
            {
                suggestions.Add(entry.Key);
            }
        }
        return suggestions;
    }
}
