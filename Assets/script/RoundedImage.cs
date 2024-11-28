using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RoundedImage : MonoBehaviour
{
    [Range(0, 0.5f)]
    public float cornerRadius = 0.1f; // Default corner radius
    private Material roundedMaterial;

    void Start()
    {
        // Get the Image component
        Image image = GetComponent<Image>();

        // Create a new instance of the material to avoid shared changes
        roundedMaterial = new Material(Shader.Find("UI/RoundedCorners"));

        // Assign the material to the Image
        image.material = roundedMaterial;

        // Apply texture from the Image component
        if (image.sprite != null)
        {
            roundedMaterial.SetTexture("_MainTex", image.sprite.texture);
        }

        // Set the initial radius
        roundedMaterial.SetFloat("_Radius", cornerRadius);
    }

    void Update()
    {
        // Update the corner radius dynamically (optional)
        if (roundedMaterial != null)
        {
            roundedMaterial.SetFloat("_Radius", cornerRadius);
        }
    }
}
