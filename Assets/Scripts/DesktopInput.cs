using System;
using UnityEngine;

public class DesktopInput : IInput
{
    public event Action OnJump;

    public Vector3 GetMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime;
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        return movement;
    }
    public Quaternion GetMovementQuaternion()
    {
        

        
            return Quaternion.LookRotation(GetMovementInput());
        
        
    }
    public void Event()
    {
        if (Input.GetKeyDown(KeyCode.Space))
       
        {
            OnJump?.Invoke();
        }
    }
    

}
