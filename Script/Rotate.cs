using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed, sensitivity, UpMax, UpMin;
    private float x, y, boundary;
    private Vector 3 = rotate;

    public void RotateCamera(Vector3 Drag)
    {
        // joystick angles
        x = -Drag.z * speed * sensitivity;
        y = Drag.x * speed * sensitivity;

        // Rotate the camera
        rotate = Vector3(x, y, 0);
        transform.Rotate(rotate);

        boundary = (transform.eulerAngles.x + x + 360) % 360;
        boundary = Mathf.Clamp(boundary, UpMin, UpMax);

        // boundary pitch for camera rotation
        transform.rotation = Quaternion.Euler(boundary, transform.eulerAngles.y, 0);   
    }
}
