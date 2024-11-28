using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnZAxis : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object around its Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
