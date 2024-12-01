using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Speed of rotation
    private Vector3 previousPosition;   // To store the last touch/mouse position
    private bool isDragging = false;   // To track if the user is interacting with the object

    void Update()
    {
        Vector3 inputPosition = Vector3.zero;
        bool isInputActive = false;

        // Check for touch input (mobile)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            inputPosition = touch.position;
            isInputActive = true;

            // Begin drag on touch start
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = CheckIfHitObject(inputPosition);
                previousPosition = inputPosition;
            }
        }
        // Check for mouse input (desktop)
        else if (Input.GetMouseButton(0))
        {
            inputPosition = Input.mousePosition;
            isInputActive = true;

            // Begin drag on mouse down
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = CheckIfHitObject(inputPosition);
                previousPosition = inputPosition;
            }
        }

        // Rotate object if dragging
        if (isInputActive && isDragging)
        {
            Vector3 delta = inputPosition - previousPosition;

            // Rotate the object based on input (horizontal and vertical movement)
            float rotationX = delta.x * rotationSpeed * Time.deltaTime;
            float rotationY = delta.y * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -rotationX, Space.World);   // Rotate around Y-axis
            transform.Rotate(Vector3.right, rotationY, Space.World); // Rotate around X-axis

            // Update the previous position
            previousPosition = inputPosition;
        }

        // Stop dragging if no input is detected
        if (!isInputActive)
        {
            isDragging = false;
        }
    }

    // Check if the input position is on this object's collider
    private bool CheckIfHitObject(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == transform; // Return true if this object is hit
        }
        return false;
    }
}
