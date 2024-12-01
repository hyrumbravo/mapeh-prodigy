using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHorizontal : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 30f;

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // If the touch is moving, calculate the rotation based on the horizontal movement
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                // Rotate around the Y-axis (horizontal rotation)
                transform.Rotate(0, -rotationX, 0);
            }
        }

        // Handle mouse input
        if (Input.GetMouseButton(0)) // Left mouse button is held
        {
            // Get the horizontal movement of the mouse
            float mouseDeltaX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

            // Rotate around the Y-axis (horizontal rotation)
            transform.Rotate(0, -mouseDeltaX, 0);
        }
    }
}
