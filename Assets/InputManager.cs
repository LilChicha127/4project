using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class InputManager : MonoBehaviour
{
    public IInput input;
    public GameObject player;
    public float Speed = 20f;
    public float jumpForce = 10f; // можно брать force так или в самом скрипте Jumping
    private Rigidbody rb;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform; //иницилизация камеры
        rb = GetComponent<Rigidbody>();
    }
    [Inject]
    public void Construct(IInput _Input)
    {
        input = _Input;
        input.OnJump += Jumper;
    }
    private void Update() //Update - применяется каждый кадр и гарантирует нажатие Input
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    player.GetComponent<Jumping>().Jump(jumpForce); // выполняется метод
        //}


        Move(Speed);
        CameraFollow();
        input.Event();
    }
    public void Jumper()
    {
        
        rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); 
    }
    public void Move(float speed)
    {
        
        transform.Translate(input.GetMovementInput() * speed);
    }
    
    private void CameraFollow()
    {


        Quaternion cameraRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0); // указывается как именно должен поворачиваться персонаж(по Y)
        transform.rotation = cameraRotation; // положение объекта становится равно положению камеры
    }
}
