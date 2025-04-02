using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class GazeBehaviour : MonoBehaviour
{
    
    public bool useMouseForDebug = false; // Toggle for mouse debugging
    void Update()
    {
        Ray gazeRay;
        
        if (!useMouseForDebug && TobiiAPI.IsConnected)
        {
            // Get the gaze ray from the eye tracker
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            if (!gazePoint.IsRecent()) return;
            gazeRay = Camera.main.ScreenPointToRay(gazePoint.Screen);
        }
        else
        {
            // Use the mouse position if debugging is enabled
            gazeRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        RaycastHit hit;
        
        // Check if the gaze or mouse ray hits a game object with a MeshRenderer
        if (Physics.Raycast(gazeRay, out hit))
        {
            if (hit.collider.GetComponent<MeshRenderer>())
            {
                Debug.Log("Gaze detected on: " + hit.collider.gameObject.name);
            }
        }
    }
}
