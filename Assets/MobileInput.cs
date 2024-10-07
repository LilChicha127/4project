using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : IInput
{
    public event Action OnJump;

    public Vector3 GetMovementInput()
    {
        // Реализация получения ввода с мобильного устройства, например, с помощью сенсорного экрана или акселерометра
        return new Vector3();
    }

    public void Event()
    {
        //if (Input.GetKey(KeyCode.Space))

        //{
        //    OnJump?.Invoke();
        //}   // Логика touch
    }
}
