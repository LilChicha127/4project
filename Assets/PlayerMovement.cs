using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 5;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform; //иницилизация камеры
    }
    private void FixedUpdate()
    {
        PlayerMove(Speed);
        CameraFollow();
    }

    private void PlayerMove(float speed) 
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime; // откуда появляется управленрие
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime;




        Vector3 movement = new Vector3(moveX, 0.0f, moveY); //  преобразование в одну переменную

        transform.Translate(movement * speed); //движение персонажа
    }
    private void CameraFollow()
    {
        
        
        Quaternion cameraRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0); // указывается как именно должен поворачиваться персонаж(по Y)
        transform.rotation = cameraRotation; // положение объекта становится равно положению камеры
    }
}
