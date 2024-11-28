using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnXAxis : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object in place along its X-axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
