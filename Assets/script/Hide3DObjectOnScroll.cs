using UnityEngine;

public class Hide3DObjectOnScroll : MonoBehaviour
{
    public RectTransform viewport; // Reference to the Scroll View's viewport
    public RectTransform content;  // Reference to the Scroll View's content
    public GameObject objectToHide; // 3D Object to hide

    private Camera uiCamera;

    void Start()
    {
        // Find the camera used for rendering UI (Screen Space - Camera)
        uiCamera = Camera.main;
    }

    void Update()
    {
        if (IsObjectOutOfBounds())
        {
            // Hide the 3D object when it's out of bounds
            objectToHide.SetActive(false);
        }
        else
        {
            // Show the 3D object when it's within bounds
            objectToHide.SetActive(true);
        }
    }

    private bool IsObjectOutOfBounds()
    {
        // Get the 3D object's position in world space
        Vector3 objectWorldPosition = objectToHide.transform.position;

        // Convert world position to viewport space
        Vector3 viewportPosition = uiCamera.WorldToViewportPoint(objectWorldPosition);

        // Ensure the object is visible in the viewport (x: 0 to 1, y: 0 to 1)
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            return true;
        }

        return false;
    }
}
