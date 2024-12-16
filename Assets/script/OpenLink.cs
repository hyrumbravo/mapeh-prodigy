using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    // Reference to the no-internet pop-up panel
    public GameObject noInternetPopup;
    private CanvasGroup canvasGroup; // For smooth fade transitions
    public float transitionDuration = 0.5f; // Duration for the fade-in/out

    private void Awake()
    {
        if (noInternetPopup != null)
        {
            // Ensure the CanvasGroup component exists
            canvasGroup = noInternetPopup.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = noInternetPopup.AddComponent<CanvasGroup>();
            }

            // Initialize the pop-up as hidden
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            noInternetPopup.SetActive(false);
        }
    }

    // Function to open a link
    public void OpenURL(string url)
    {
        // Check internet connectivity
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // Show a pop-up if no internet
            ShowNoInternetPopup();
        }
        else
        {
            // Open the URL
            Application.OpenURL(url);
        }
    }

    // Function to display a pop-up for no internet with transition
    private void ShowNoInternetPopup()
    {
        if (noInternetPopup != null)
        {
            noInternetPopup.SetActive(true); // Make the panel active
            StartCoroutine(FadeCanvasGroup(canvasGroup, 0f, 1f, transitionDuration)); // Fade in
        }
        else
        {
            Debug.LogWarning("NoInternetPopup GameObject is not assigned in the Inspector.");
        }
    }

    // Function to close the pop-up with transition
    public void CloseNoInternetPopup()
    {
        if (noInternetPopup != null)
        {
            StartCoroutine(FadeOutAndDeactivate(canvasGroup, transitionDuration)); // Fade out and deactivate
        }
    }

    // Coroutine to fade in/out the CanvasGroup
    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        cg.alpha = endAlpha;
        cg.interactable = endAlpha > 0;
        cg.blocksRaycasts = endAlpha > 0;
    }

    // Coroutine to fade out and deactivate the pop-up
    private IEnumerator FadeOutAndDeactivate(CanvasGroup cg, float duration)
    {
        yield return StartCoroutine(FadeCanvasGroup(cg, 1f, 0f, duration));
        noInternetPopup.SetActive(false); // Deactivate after fading out
    }
}
