using UnityEngine;
using Tobii.Gaming;

public class ExplodeOnGaze : MonoBehaviour
{
    private float gazeTime = 0f;
    private float requiredGazeTime = 2f;
    private bool isGazedAt = false;

    public GameObject explosionEffect; // Assign an explosion effect prefab in Unity
    private Renderer objectRenderer;
    private Color originalColor;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    void Update()
    {
        if (IsLookingAtObject())
        {
            if (!isGazedAt)
            {
                isGazedAt = true;
                gazeTime = Time.time; // Start counting gaze time
            }
            else
            {
                float gazeProgress = (Time.time - gazeTime) / requiredGazeTime; // Normalize from 0 to 1
                gazeProgress = Mathf.Clamp01(gazeProgress); // Ensure it stays between 0 and 1
                
                ChangeColor(gazeProgress);

                if (gazeProgress >= 1f)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            isGazedAt = false;
            gazeTime = Time.time; // Reset timer
            ChangeColor(0); // Fade back to original color
        }
    }

    bool IsLookingAtObject()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (!gazePoint.IsRecent()) return false; // Check if gaze data is valid

        Vector3 gazeScreenPos = gazePoint.Screen;
        Camera mainCamera = Camera.main;

        // Convert screen position to world ray
        Ray gazeRay = mainCamera.ScreenPointToRay(new Vector3(gazeScreenPos.x, gazeScreenPos.y, 0));

        RaycastHit hit;
        if (Physics.Raycast(gazeRay, out hit))
        {
            Debug.Log("Gaze is hitting: " + hit.transform.name); // Debug log to check if ray hits object
            return hit.transform == transform;
        }
        return false;
    }

    void ChangeColor(float intensity)
    {
        Color targetColor = Color.Lerp(originalColor, Color.red, intensity);
        objectRenderer.material.color = targetColor;
    }
}