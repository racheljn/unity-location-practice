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
        // GS25, Gonzaga Hall, Cafeteria
        if  (Lat >= 37.5508 - MarginOfError && Lat <= 37.5510 + MarginOfError && Long >= 126.9436 - MarginOfError && Long <= 126.94440 + MarginOfError
                || Lat >= 37.5505 - MarginOfError && Lat <= 37.5513 + MarginOfError && Long >= 126.9435 - MarginOfError && Long <= 126.9437 + MarginOfError
                || Lat >= 37.5502 - MarginOfError && Lat <= 37.5509 + MarginOfError && Long >= 126.9387 - MarginOfError && Long <= 126.9391)       
        {
            return "Eating Area";
        }        
        else if (Lat >= 37.5508 - MarginOfError && Lat <= 37.5517 - MarginOfError && Long >= 126.9439 - MarginOfError && Long <= 126.9440 + MarginOfError) {
            return "Gonzaga Hall";
        }
        else if (Lat >= 37.5513 - MarginOfError && Lat <= 37.5517 && Long <= 126.9428 - MarginOfError && Long >= 126.9437 + MarginOfError)
        {
            return "Classroom";
        }
        else if (Lat >= 37.5503 - MarginOfError && Lat <= 37.5507 + MarginOfError && Long <= 126.9406 - MarginOfError && Long >= 126.9421 + MarginOfError)
        {
            return "Field";
        }


        if (Lat > 37.54906 - MarginOfError && Lat < 37.54906 + MarginOfError && Long > 126.9386 - MarginOfError && Long < 126.9386 + MarginOfError)
        {
            return "Cafe";
        }

        return "Hasn't been mapped";
    }
}
