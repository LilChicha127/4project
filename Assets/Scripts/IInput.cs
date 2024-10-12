using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInput 
{
    public void Event();
    Vector3 GetMovementInput();
    public event Action OnJump;
    Quaternion GetMovementQuaternion();
}
