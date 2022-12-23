using System;
using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rb => GetComponent<Rigidbody>();
    
    private float speed = 4;
    private float turnSpeed = 480;

    private Vector3 controlAxis;

    void Update()
    {
        gatherInput();
        Look();
    }
    void FixedUpdate()
    {
        move();
    }

    void gatherInput()
    {
        controlAxis = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        controlAxis.Normalize();
    }

    void Look()
    {
        if (controlAxis != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));

            var skewedInput = matrix.MultiplyPoint3x4(controlAxis);


            var releative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(releative,Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot,turnSpeed * Time.deltaTime);
        }
    }

    void move()
    {
        rb.MovePosition(transform.position + (controlAxis.magnitude * transform.forward) * speed * Time.deltaTime);
    }
}
