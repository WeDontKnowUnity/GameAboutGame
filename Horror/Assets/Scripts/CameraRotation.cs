using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    public Transform player;
    float Speed = 3f;
    float x,y;
    private void FixedUpdate() 
    {
        x += joystick.Horizontal * Speed;
        y -= joystick.Vertical * Speed;
        
        if (y <= 90 && y >= -90)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.rotation = rotation;
            player.rotation = Quaternion.Euler(0, x, 0);
        }
        
        
        
        // if (Input.touchCount > 0)
        // {
        //     if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //     {
        //         Touch touch = Input.GetTouch(0);

        //         if (touch.position.x > Screen.width / 2)
        //         {
        //             x += touch.deltaPosition.x * xSpeed * 0.02f;
        //             y -= touch.deltaPosition.y * ySpeed * 0.02f;

        //             if (y < 90 && y > -90)
        //             {
        //                 Quaternion rotation = Quaternion.Euler(y, x, 0);
        //                 transform.rotation = rotation;
        //             }
                    
                    
        //         }
        //     }
        // }

    }
}
