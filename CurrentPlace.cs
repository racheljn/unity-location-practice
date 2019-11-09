using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlace : MonoBehaviour
{
    public Text Coordinates;
    public float MarginOfError;
    private float CurrentLat;
    private float CurrentLong;

    private void Update()
    {
        CurrentLat = LocationTracker.Instance.latitude;
        CurrentLong = LocationTracker.Instance.longitude;
        Coordinates.text = CurrentZone(CurrentLat, CurrentLong) + "Lat:" + CurrentLat.ToString() + "     Lon:" + CurrentLong.ToString();
    }

    private string CurrentZone(float Lat, float Long)
    {
        // Checks if latitude and longitude is in range
        // Note: Put smallest lat/long first, then greater lat/long
        if (Lat > 37.54906 - MarginOfError && Lat < 37.54906 + MarginOfError && Long > 126.9386 - MarginOfError && Long < 126.9386 + MarginOfError)
        {
            return "Cafe";
        }

        return "Hasn't been mapped";
    }
}
