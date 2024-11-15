using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class InputManager : MonoBehaviour
{
    public IInput input;
    public GameObject player;
    public float Speed = 20f;
    public bool box;
    private Rigidbody rb;
    private Transform cameraTransform;
    public int A, B, C;        //стандарт: A = 0, B = 8, C = -15
    private Animator animator;
    
    private void Start()
    {
        cameraTransform = Camera.main.transform; //иницилизация камеры
        rb = player.GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();

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
    private void FixedUpdate()
    {
        Move(Speed);
        
    }
    private void Update()
    {
        

        
        CameraFollow();
        input.Event();
    }
    public void Jumper()
    {
       
    }
    public void Move(float speed)
    {


        
        rb.velocity = (input.GetMovementInput() * speed);
        if (input.GetMovementInput().magnitude > 0)
        {
            animator.speed = 1f;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, input.GetMovementQuaternion(), Time.deltaTime * 10f);
            // пока не стал запариваться над анимацией

            if (box)
            {
                animator.Play("RunWithBox");
            }
            else
            {
                animator.Play("Run");
            }
        }
        else
        {
            if (box)
            {
                animator.speed = 0f;
                
            }
            else 
            { 
                animator.Play("Idle");
            }
            
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
