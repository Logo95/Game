using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic movement
    public float moveSpeed = 20f;
    public Rigidbody rb;
    [HideInInspector] public Vector3 moveDirection;
    [HideInInspector] public Vector3 MouseDir;
    [SerializeField] private Camera cam;
    void Update(){
        ProcessInputs();
        ProcessMousePos();
        rb.velocity = moveDirection * moveSpeed;
        

        //transform.LookAt(mousePos);
    }

    void ProcessInputs(){
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
    }

    void ProcessMousePos(){
        Vector3 mouse = Input.mousePosition;
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, cam.transform.position.y - rb.position.y));
        MouseDir = new Vector3(mousePos.x - transform.position.x,
                                       mousePos.y - transform.position.y ,
                                       mousePos.z - transform.position.z);
        transform.rotation = Quaternion.LookRotation(MouseDir);

    }
    
}
