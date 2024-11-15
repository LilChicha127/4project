using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInput 
{
    public void Event();
    public void EventInteract();
    Vector3 GetMovementInput();
    public event Action OnJump, OnInteract;
    Quaternion GetMovementQuaternion();
}
