using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 60f; // in seconds
    public Light sunLight;
    
    private float rotationSpeed;

    void Start()
    {
        rotationSpeed = 360f / dayDuration; // Calculate rotation speed based on day duration
    }

    void Update()
    {
        UpdateDayNightCycle();
    }

    void UpdateDayNightCycle()
    {
        // Rotate the sun based on the time of day
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);

        // Adjust light intensity based on sun's elevation (optional)
        float lightIntensity = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down));
        sunLight.intensity = lightIntensity;

        // Example: Change sky color based on time of day (you might need a Skybox)
        RenderSettings.skybox.SetFloat("_Exposure", 1f - lightIntensity);
    }
}
