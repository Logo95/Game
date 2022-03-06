using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic movement
    public float moveSpeed = 20f;

    public Rigidbody rb;

    [HideInInspector] public Vector3 moveDirection;

    [HideInInspector] public Vector3 mouseDir;



    void FixedUpdate(){
        ProcessInputs();
        ProcessMousePos();
        rb.velocity = moveDirection * moveSpeed;
    }

    void ProcessInputs(){
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
    }

    void ProcessMousePos(){
        Vector3 mouse = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit rHit;
        Vector3 mousePos = new Vector3(0,0,0);
        if (Physics.Raycast(ray, out rHit, 100)) {
            mousePos = rHit.point;
        }
        mouseDir = mousePos - transform.position;
        mouseDir.y = 0;
        transform.LookAt(transform.position + mouseDir, Vector3.up);

    }
    
}
