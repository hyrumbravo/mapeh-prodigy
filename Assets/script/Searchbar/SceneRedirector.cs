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
        { "racket games", "Racketgames" },
        { "board game", "boardgame homepage" },

        //basketball
        { "basketball", "bball intro" },

        //basketball faci/equip
        { "basketball court", "faci(court)bball" },
        { "basketball(ball)", "faci(3dball)bball" },
        { "basketball ring and board", "faci(ringboard)bball" },

        //basketball defensive rule
        { "defensive rule", "bball defensiverules" },

        //basketball offensive rule
        { "offensive rule", "bball offensiverules" },

        //basketball foul
        { "personal foul", "rule1 foul bball" },
        { "technical foul", "rule2 foul bball" },
        { "flagrant foul", "rule3 foul bball" },
        { "looseball foul", "rule4 foul bball" },

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
        { "dribbling(basketball)", "dribbling bball" },
        { "passing(basketball)", "passing bball" },
        { "rebounding(basketball)", "rebound bball" },
        { "shooting(basketball)", "shooting bball" },

        //basketball glossary
        { "basketball glossary of terms", "bball glossary and terms" },

 



        //sepak intro
        { "sepak takraw", "sepak intro" },

        //sepak faci/equip
        { "takraw ball", "faci(3dball)sepak" },
        { "rattan ball", "faci(3dball)sepak" },
        { "sepak court", "faci(court)sepak" },
        { "net(sepak)", "faci(net)sepak" },



        //sepak glossary
        { "sepak glossary of terms", "sepak glossary and terms" },


        //sepak rules
        { "sepak violations", "sepak ruleviolation" },
        { "sepak defensive rule", "sepak defensive rules" },
        { "sepak offensive rule", "sepak offensiverules" },


        //sepak skills
        { "serving(sepak)", "serving sepak skill" },
        { "passing(sepak)", "passing sepak skill" },
        { "spiking(sepak)", "spiking sepak skill" },
        { "blocking(sepak)", "blocking sepak skill" },
        { "ball control(sepak)", "ballcontrol sepak skill" },



        //soccer intro
        { "soccer", "soccer intro" },

        //soccer facilities
        { "soccer ball", "faci(3dball)soccer" },
        { "soccer field", "faci(field)soccer" },
        { "soccer goal", "faci(goal)soccer" },

         //soccer glossary
        { "soccer glossary of terms", "soccer intro" },


        //soccer rule violation
        { "soccer violations", "soccer rulesViolation" },

        //soccer rule violation
        { "soccer offensive rules", "soccer offensiverules" },
        { "soccer defensive rules", "soccer defensiverules" },

        { "hand ball", "rule1 rule violation soccer" },
        { "foul play", "rule2 rule violation soccer" },
        { "dangerous play", "rule3 rule violation soccer" },
        { "obstruction", "rule4 rule violation soccer" },
        { "back pass", "rule5 rule violation soccer" },


        //soccer skills
        { "dribbling(soccer)", "dribbling soccer" },
        { "juggling(soccer)", "juggling soccer" },
        { "passing(soccer)", "passing soccer" },
        { "shooting(soccer)", "shooting soccer" },



        //vball
        { "volleyball", "vball intro" },

        //vball facilities
        { "volleyball(ball)", "ball faci vball" },
        { "volleyball court", "court faci vball" },
        { "volleyball net and pole", "court NetPole vball" },


        //vball skill
        { "blocking(volleyball)", "blocking vball" },
        { "digging(volleyball)", "digging vball" },
        { "passing(volleyball)", "passing vball" },
        { "serving(volleyball)", "serve vball" },
        { "setting(volleyball)", "setting vball" },
        { "spiking(volleyball)", "spiking vball" },

        //vball violation
        { "volleyball violations", "vball ruleviolations" },
        { "volleyball offensive rules", "vball offensiverules" },
        { "volleyball defensive rules", "vball defensiverules" },

        //vball glossary
        { "volleyball glossary of terms", "vball glossary and terms" },





        //chess
        { "chess", "chess intro" },

        //chess pieces and board
        { "bishop", "bishop" },
        { "chess board", "chessboard" },
        { "king", "king" },
        { "knight", "knight" },
        { "pawn", "pawn" },
        { "queen", "queen" },
        { "rook", "rook" },


        //chess movement
        { "chess pieces movement rules", "homepage skill chess" },

        //chess rules
        { "chess rules", "homepage chess rules" },
        { "castling", "castling" },
        { "checkmate", "check and checkmate" },

        //chess glossary of terms
        { "chess glossary of terms", "glossary chess" },




        //badminton 
        { "badminton", "badminton intro" },

        //badminton faci
        { "badminton court", "court badminton 1" },
        { "badminton racket", "racket badminton" },
        { "shuttlecock", "Shuttle badminton" },

        //badminton rules
        { "badminton violations", "RuleViolation homepage badminton" },
        { "badminton offensive rules", "badminton offensive homepage" },
        { "badminton defensive rules", "badminton defensive homepage" },

        //badminton glossary
        { "badminton glossary of terms", "Terminologies Badminton" },



        //badminton skills
        { "clear(badminton)", "clear badminton" },
        { "drive(badminton)", "drive badminton" },
        { "dropshot(badminton)", "dropshot badminton" },
        { "high serve(badminton)", "highserve badminton" },
        { "low serve(badminton)", "lowserve badminton" },
        { "smash(badminton)", "smash badminton" },



        //tabletennis intro
        { "table tennis", "tabletennis intro" },

        //tabletennis faci
        { "table tennis ball", "faci(3dball)tabletennis" },
        { "table tennis racket", "faci(racket)racket" },
        { "table tennis table", "faci(table)tabletennis" },

        //tabletennis rule
        { "table tennis game rule", "tabletennis gamerule homepage" },
        { "table tennis violations", "tabletennis violation homepage" },

        //tabletennis glossary
        { "table tennis glossary of terms", "tabletennis glossary and terms" },



        //pickleball intro
        { "pickleball", "Pickleball homepage" },

        //pickleball faci
        { "pickleball (ball)", "faci(3dball)pickleball" },
        { "pickleball paddle", "faci(paddle)pickleball" },
        { "pickleball court", "faci(court)pickleball" },

        //pickleball rule
        { "pickleball rule violation", "pickle ball violation homepage" },


        //pickleball glossary
        { "pickleball glossary of terms", "pickleball glossary and terms" },
    


    
    





        
        


        








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
