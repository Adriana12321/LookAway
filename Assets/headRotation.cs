using Tobii.Gaming;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public Transform head;  // Assign the head or camera transform
    public float rotationFactor = 5f; // Adjust sensitivity

    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent())
        {
            Vector2 screenPos = gazePoint.Screen;
            float xOffset = (screenPos.x - Screen.width / 2f) / (Screen.width / 3f);
            float yOffset = (screenPos.y - Screen.height / 2f) / (Screen.height / 3f);

            head.localRotation = Quaternion.Euler(-yOffset * rotationFactor, xOffset * rotationFactor, 0);
        }
    }
}
