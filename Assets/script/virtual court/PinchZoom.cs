using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public Camera targetCamera; // Assign the perspective camera you want to zoom
    public float zoomSpeed = 0.1f; // Adjust zoom sensitivity
    public float minZoom = 15f;    // Minimum field of view (zoomed in)
    public float maxZoom = 90f;    // Maximum field of view (zoomed out)

    void Update()
    {
        // Mouse scroll input (laptop/desktop)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            targetCamera.fieldOfView = Mathf.Clamp(targetCamera.fieldOfView - scroll * zoomSpeed * 10, minZoom, maxZoom);
        }

        // Pinch zoom input (mobile devices)
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            // Calculate the distance between touches
            float prevDistance = (touch1.position - touch1.deltaPosition).magnitude -
                                 (touch2.position - touch2.deltaPosition).magnitude;
            float currentDistance = (touch1.position - touch2.position).magnitude;

            // Calculate zoom factor
            float zoomChange = (currentDistance - prevDistance) * zoomSpeed;

            // Adjust the camera's field of view
            targetCamera.fieldOfView = Mathf.Clamp(targetCamera.fieldOfView - zoomChange, minZoom, maxZoom);
        }
    }
}
