using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Jump(float impulse)
    {
        rb.AddForce(Vector3.up * impulse,ForceMode.Impulse); // реализация прыжка
    }
}

