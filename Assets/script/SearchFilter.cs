using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SearchFilter : MonoBehaviour
{
    public InputField searchField;  // Reference to the InputField for search
    public Transform content;       // Reference to the ScrollView Content (Parent of list items)
    
    private GameObject[] allItems;

    void Start()
    {
        // Store all children (list items) under the content object
        allItems = content.Cast<Transform>().Select(t => t.gameObject).ToArray();

        // Add a listener to the searchField to detect changes in input
        searchField.onValueChanged.AddListener(OnSearchValueChanged);
    }

    // This method gets triggered every time the input in the search field changes
    void OnSearchValueChanged(string searchText)
    {
        foreach (var item in allItems)
        {
            // Check if the item's name or any relevant text matches the search input
            bool isMatch = string.IsNullOrEmpty(searchText) || 
                           item.name.ToLower().Contains(searchText.ToLower());

            // Show the item if it matches the search query, otherwise hide it
            item.SetActive(isMatch);
        }

        // Force the layout to rebuild after filtering
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
    }
}
