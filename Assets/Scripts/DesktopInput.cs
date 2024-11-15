using System;
using Unity.VisualScripting;
using UnityEngine;

public class DesktopInput : IInput
{
    public event Action OnJump, OnClicked, OnExit, OnInteract;
    

 

    



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
    public void EventInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract?.Invoke();
            
        }
    }
    public void Event()
    {
        if (Input.GetKeyDown(KeyCode.Space))
       
        {
            OnJump?.Invoke();
        }
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            OnExit?.Invoke();
       
    }
    

}
