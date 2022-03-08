using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float moveSpeed;
    [HideInInspector] public Rigidbody rb;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    [HideInInspector] public Vector3 pointToLook;

    private Camera mainCamera;

    public GunController gun;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update(){
        // if (Input.GetMouseButtonDown(0))
        //     gun.isFiring = true;

        // if (Input.GetMouseButtonUp(0))
        //     gun.isFiring = false;
    }


    void FixedUpdate(){
        moveInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f , Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        MousePos();
        rb.velocity = moveInput * moveSpeed;
    }

    void MousePos(){
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght)){
            pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}
