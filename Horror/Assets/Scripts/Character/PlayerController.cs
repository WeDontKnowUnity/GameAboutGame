using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float speed = 1.7f;
    CharacterController _chControl;

    void Start()
    {
        _chControl = GetComponent<CharacterController>();
    }
    
    private void Update()
    {

        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            return; 
        } 
        else
        {
            Vector3 change = new Vector3(0, -9.8f, 0);

            Vector3 moving = transform.forward * joystick.Vertical * speed + transform.right * joystick.Horizontal * speed;
            _chControl.SimpleMove((change + moving) *speed);
        }
        
    }
}
