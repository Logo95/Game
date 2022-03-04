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
        //Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, cam.transform.position.y - rb.position.y));
        
        // mouseDir = new Vector3((mousePos.x - transform.position.x) * 100,
        //                                transform.position.y ,
        //                                (mousePos.z - transform.position.z) * 100);
        Ray ray = cam.ScreenPointToRay(mouse);
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
