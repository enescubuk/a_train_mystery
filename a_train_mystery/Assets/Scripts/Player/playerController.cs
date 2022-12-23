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
    }

    void Look()
    {
        if (controlAxis != Vector3.zero)
        {
            var releative = (transform.position + controlAxis) - transform.position;
            var rot = Quaternion.LookRotation(releative,Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot,turnSpeed * Time.deltaTime);
        }
    }

    void move()
    {
        rb.MovePosition(transform.position + (controlAxis.magnitude * transform.forward) * speed * Time.deltaTime);
    }
}
