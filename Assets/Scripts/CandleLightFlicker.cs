using UnityEngine;
using UnityEngine.Rendering.Universal; // חובה כדי לגשת ל-Light2D

[RequireComponent(typeof(Light2D))]
public class CandleLightFlicker : MonoBehaviour
{
    private Light2D _light2D;

    [Header("Intensity Settings")]
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    [Range(0.01f, 0.5f)] public float flickerSpeed = 0.1f;

    [Header("Radius Settings")]
    public float minRadius = 4.5f;
    public float maxRadius = 5.0f;

    private float _noiseOffset;

    void Start()
    {
        _light2D = GetComponent<Light2D>();
        // הגרלת נקודת התחלה לרעש כדי שלא כל הנרות יבהבו אותו דבר
        _noiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // שימוש ב-PerlinNoise ליצירת שינויים חלקים
        float noise = Mathf.PerlinNoise(_noiseOffset, Time.time * (flickerSpeed * 10));
        
        // החלת עוצמת האור
        _light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        
        // החלת רדיוס האור (דימוי של הלהבה שגדלה וקטנה)
        _light2D.pointLightOuterRadius = Mathf.Lerp(minRadius, maxRadius, noise);
    }
}