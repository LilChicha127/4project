using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private Vector2 _rotation;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // управление камеры

        _rotation.y += mouseX;
        _rotation.x -= mouseY; // иницилизация осей

        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90); // ограничение в 90 и -90 градусов по X

        transform.eulerAngles = new Vector3(_rotation.x, _rotation.y, 0); // реализация управление

    }
}
