using System;
using UnityEngine;
using TMPro; 

public class Clock : MonoBehaviour
{
    const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;
    public double timeZoneOffset = 0;
    public TextMeshPro textMeshPro; 

    void Awake()
    {
        var time = DateTime.UtcNow.AddHours(timeZoneOffset);  
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);

        if (textMeshPro != null)
        {
            Transform textTransform = textMeshPro.transform;

            textTransform.localPosition = new Vector3(0, -0.0129f, 0.0007f); //Positon
            textTransform.localScale = new Vector3(0.01f, 0.01f, 0.01f); //Scale
            textTransform.localRotation = Quaternion.Euler(0, 180, 0); //Rotation
            textMeshPro.alignment = TextAlignmentOptions.Center;
            textMeshPro.fontSize = 3; //Font size
            textMeshPro.color = Color.black; //Color
        }
    }
    void Update()
    {
        TimeSpan time = DateTime.UtcNow.AddHours(timeZoneOffset).TimeOfDay; 
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);
    }
}
