using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed;

  
    private void FixedUpdate()
    {

        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            return; 
        } 
        else
        {
            rb.velocity = transform.forward * joystick.Vertical * speed + transform.right * joystick.Horizontal * speed; 
        }
        
    }
}
