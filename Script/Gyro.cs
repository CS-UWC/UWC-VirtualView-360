using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    public Tour tour;
    private bool gyroOn;
    private Gyroscope gyro;
    private Quaternion gyroInitial, temp, fixAtt, offset;
   
    private void Start () {
        gyroOn = enableGyro();      
    }

    private bool enableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            temp = tour.transform.rotation;
            transform.rotation = gyro.attitude;

            gyroInitial = Quaternion.identity;

            return true;
        }
        return false;
    }
   
    private void Update () {

        if(gyroOn){
            fixAtt = new Quaternion (gyro.attitude.x, gyro.attitude.y, -gyro.attitude.z, -gyro.attitude.w);

            offset = Quaternion.Inverse (gyroInitial) * fixAtt;
            
            transform.rotation = temp * Quaternion.Euler(90.0f, 0.0f, 0.0f) * offset;
        }
    }

}
