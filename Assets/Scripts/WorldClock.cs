using System.Collections.Generic;
using UnityEngine;

public class WorldClock : MonoBehaviour
{
    public GameObject clockPrefab;

    // NewYork -4, NewDehli +5:30, Seattle -7, Paris +2, Tokyo +9, Sydney +10, London 0, Honolulu -10, Dubai 4, Beijing 8
 
    void Start()
    {
        CreateClock(new Vector3(0, 0, -0.6f), Quaternion.Euler(0, 0, 0), -4, "New York");
        CreateClock(new Vector3(0, 3, -0.6f), Quaternion.Euler(0, 0, 0), 2, "Paris");

        CreateClock(new Vector3(-2.7f, 0, 0), Quaternion.Euler(0, 22.5f, 0), 5.5, "New Dehli");
        CreateClock(new Vector3(2.7f, 0, 0), Quaternion.Euler(0, -22.5f, 0), -7, "Seattle");

        CreateClock(new Vector3(-2.7f, 3, 0), Quaternion.Euler(0, 22.5f, 0), 9, "Tokyo");
        CreateClock(new Vector3(2.7f, 3, 0), Quaternion.Euler(0, -22.5f, 0),10, "Sydney");

        CreateClock(new Vector3(-5.5f, 0, 0), Quaternion.Euler(0, 45f, 0), 0, "London");
        CreateClock(new Vector3(5.5f, 0, 0), Quaternion.Euler(0, -45, 0), -10, "Honolulu");

        CreateClock(new Vector3(-5.5f, 3, 0), Quaternion.Euler(0, 45f, 0), 4, "Dubai");
        CreateClock(new Vector3(5.5f, 3, 0), Quaternion.Euler(0, -45f, 0),8, "Beijing");
        // Add more clocks as needed
    }

    void CreateClock(Vector3 position, Quaternion rotation, double timeZoneOffset, string text)
    {
        GameObject clock = Instantiate(clockPrefab, position, rotation);
        Clock clockScript = clock.GetComponent<Clock>();
        clock.name = text + " Clock";
        if (clockScript != null)
        {
            clockScript.timeZoneOffset = timeZoneOffset;
            if (clockScript.textMeshPro != null)
            {
                clockScript.textMeshPro.text = text;
            }
        }
    }
}

