using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateVertical : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 30f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationY = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;

                // Get the current rotation
                Vector3 currentRotation = transform.eulerAngles;

                // Adjust only the Y-axis rotation to keep it horizontal
                transform.eulerAngles = new Vector3(currentRotation.x, currentRotation.y - rotationY, currentRotation.z);
            }
        }
    }
}
