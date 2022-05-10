using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    float xSpeed = 2f;
    float ySpeed = 2f;
    float x,y;
    void Update () 
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.position.x > Screen.width / 2)
                {
                    x += touch.deltaPosition.x * xSpeed * 0.02f;
                    y -= touch.deltaPosition.y * ySpeed * 0.02f;

                    Quaternion rotation = Quaternion.Euler(y, x, 0f);

                    transform.rotation = rotation;
                }
            }
        }
    }
}
