using UnityEngine;

public class DisplayFavorites : MonoBehaviour
{
    public GameObject buttonPrefab; // Reference to the button prefab
    public Transform parentTransform; // Parent object for instantiated buttons

    private void Start()
    {
        // Loop through all possible saved buttons
        for (int i = 0; i < 10; i++) // Adjust the range to match the max number of buttons
        {
            string key = "faveStatus_button" + i;

            if (PlayerPrefs.HasKey(key) && PlayerPrefs.GetInt(key) == 1)
            {
                // Get saved position and parent name
                float posX = PlayerPrefs.GetFloat(key + "_posX", 0);
                float posY = PlayerPrefs.GetFloat(key + "_posY", 0);
                float posZ = PlayerPrefs.GetFloat(key + "_posZ", 0);
                string parentName = PlayerPrefs.GetString(key + "_parent", "null");

                // Instantiate the button
                GameObject newButton = Instantiate(buttonPrefab, parentTransform);
                newButton.name = "button" + i;
                newButton.transform.position = new Vector3(posX, posY, posZ);

                // Attach to the correct parent if applicable
                if (parentName != "null")
                {
                    Transform parent = GameObject.Find(parentName)?.transform;
                    if (parent != null)
                    {
                        newButton.transform.SetParent(parent, false);
                    }
                }
            }
        }
    }
}
