using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTracker : MonoBehaviour
{
     public static LocationTracker Instance { set; get; }

     public float latitude;
     public float longitude;

    IEnumerator coroutine;

     // Start is called before the first frame update
     void Start()
     {
         Instance = this;
         DontDestroyOnLoad(gameObject);
         StartCoroutine(StartLocationService());
     }

     private IEnumerator StartLocationService()
     {
         coroutine = updateGPS();   

         if (!Input.location.isEnabledByUser)
         {
             Debug.Log("User has not enabled location tracking");
             yield break;
         }

         Input.location.Start();
         int maxWait = 20;

         while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
         {
             yield return new WaitForSeconds(1);
             maxWait--;
         }

         if (maxWait <= 0)
         {
             Debug.Log("Timed out");
             yield break;
         }

         if (Input.location.status == LocationServiceStatus.Failed)
         {
             Debug.Log("Unable to determine device location");
             yield break;
         }

         latitude = Input.location.lastData.latitude;
         longitude = Input.location.lastData.longitude;
         StartCoroutine(coroutine);

        // yield break;
     }

    IEnumerator updateGPS()
    {
        float UPDATE_TIME = 3f; //Every  3 seconds
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);

        while (true)
        {
            //print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            longitude = Input.location.lastData.longitude;
            latitude = Input.location.lastData.latitude;
            yield return updateTime;
        }
    }

    void stopGPS()
    {
        Input.location.Stop();
        StopCoroutine(coroutine);
    }

    void OnDisable()
    {
        stopGPS();
    }

}
