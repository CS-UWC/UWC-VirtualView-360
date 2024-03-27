using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed, sensitivity, max, min;
    private float x, y, boundary, limit;
    private Vector3 rotate;

    public void RotateCamera(Vector3 Drag)
    {
        x = -Drag.z * speed * sensitivity;
        y = Drag.x * speed * sensitivity;
      
        // Rotate the camera
        transform.Rotate(x, y, 0);

        limit = transform.eulerAngles.x + x;
        if(limit > 180)
        {
          limit -= 360;
        }

        boundary = Mathf.Clamp(limit, min, max);

        transform.rotation = Quaternion.Euler(boundary, transform.eulerAngles.y, 0);
 
    }
}
