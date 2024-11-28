using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoScroll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ScrollRect scrollRect;  // Reference to the ScrollRect component
    public float scrollSpeed = 0.01f; // Speed of the automatic scrolling

    private bool isScrollingRight = true; // Indicates the current scrolling direction
    private bool isUserHolding = false; // Indicates if the user is interacting with the scroll view

    void Update()
    {
        // Only scroll if the user is not holding/touching the scroll view
        if (scrollRect != null && !isUserHolding)
        {
            // Adjust the scroll position based on the direction
            if (isScrollingRight)
            {
                scrollRect.horizontalNormalizedPosition += scrollSpeed * Time.deltaTime;

                // Check if it has reached the end
                if (scrollRect.horizontalNormalizedPosition >= 1f)
                {
                    isScrollingRight = false; // Reverse direction
                }
            }
            else
            {
                scrollRect.horizontalNormalizedPosition -= scrollSpeed * Time.deltaTime;

                // Check if it has reached the start
                if (scrollRect.horizontalNormalizedPosition <= 0f)
                {
                    isScrollingRight = true; // Reverse direction
                }
            }
        }
    }

    // Detect when the user touches or holds the scroll view
    public void OnPointerDown(PointerEventData eventData)
    {
        isUserHolding = true; // Stop automatic scrolling
    }

    // Detect when the user releases the touch
    public void OnPointerUp(PointerEventData eventData)
    {
        isUserHolding = false; // Resume automatic scrolling
    }
}
