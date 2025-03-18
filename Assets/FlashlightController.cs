using UnityEngine;

public class FlashlightFlicker : MonoBehaviour
{
    public float flickerIntensity = 0.5f; // Intensity variation
    public float flickerSpeed = 0.1f; // Speed of flickering

    private Light flashlight;
    private float baseIntensity;

    void Start()
    {
        flashlight = GetComponent<Light>();
        baseIntensity = flashlight.intensity;
    }

    void Update()
    {
        // Randomly adjust the intensity to create a flickering effect
        float randomIntensity = Random.Range(baseIntensity - flickerIntensity, baseIntensity + flickerIntensity);
        flashlight.intensity = randomIntensity;
    }
}