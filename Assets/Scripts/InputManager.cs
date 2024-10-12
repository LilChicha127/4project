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
    public int A, B, C;        //стандарт: A = 0, B = 8, C = -15
    private void Start()
    {
        cameraTransform = Camera.main.transform; //иницилизация камеры
        rb = player.GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        input.OnJump += Jumper;
    }
    [Inject]
    public void Construct(IInput _Input)
    {
        input = _Input;
        
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
        
        player.transform.Translate(input.GetMovementInput() * speed , Space.World);
        if (input.GetMovementInput().magnitude > 0)
        {
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, input.GetMovementQuaternion(), Time.deltaTime * 10f);
        }
           
       
    }
    
    private void CameraFollow()
    {

        
        cameraTransform.position = new Vector3(player.transform.position.x + A, player.transform.position.y + B, player.transform.position.z+C);

    }
    private void OnDisable()
    {
        input.OnJump -= Jumper;
    }
}
