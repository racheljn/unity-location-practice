using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlace : MonoBehaviour
{
    public Text coordinates;
    private float currentLat; 
    private float currentLon; 

    private void Update()
    {
        currentLat = LocationTracker.Instance.latitude;
        currentLon = LocationTracker.Instance.longitude;
        coordinates.text = CurrentZone(currentLat, currentLon) + "Lat:" + currentLat.ToString() + "     Lon:" + currentLon.ToString();
    }

    private string CurrentZone(float Lat, float Lon)
    {
        if (currentLat > 37.54904 && currentLat < 47.54910 && currentLon > 126.9384 && currentLon < 126.9391)
        {
            return "Cafe";
        }

        return "Hasn't been mapped";
    }
}
