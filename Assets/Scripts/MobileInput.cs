using System;
using UnityEngine;
using UnityEngine.UI;
public class MobileInput : IInput
{
    public event Action OnJump, OnInteract;


    private Joystick _joystick;
    public MobileInput(Joystick joystick)
    {


        _joystick = joystick;
    }

    public Vector3 GetMovementInput()
    {




        Vector3 movement = new Vector3(_joystick.Horizontal, 0.0f, _joystick.Vertical) * Time.deltaTime;

        return movement;
    }
    public void EventInteract()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    OnInteract?.Invoke();
        
        //}
    }
    public Quaternion GetMovementQuaternion()
    {
        
        

       
            return Quaternion.LookRotation(GetMovementInput());
        
        
    } 


    public void Event()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            OnJump.Invoke();
        }
    }
}
