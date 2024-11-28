using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float bounceSpeed = 2.0f; // Speed of the bounce
    public float bounceHeight = 0.2f; // Maximum height of the bounce

    private Vector3 originalLocalPosition; // Original local position of the text

    void Start()
    {
        originalLocalPosition = transform.localPosition; // Store the initial local position
    }

    void Update()
    {
        // Calculate the bounce effect for the Y-axis
        float newY = originalLocalPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Update the local position while keeping X and Z unchanged
        transform.localPosition = new Vector3(originalLocalPosition.x, newY, originalLocalPosition.z);
    }
}
