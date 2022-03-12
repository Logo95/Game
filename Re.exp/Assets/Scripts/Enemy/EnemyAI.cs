using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController player;
    private Vector3 directionToLook;
    private Vector3 currentLookDirection;
    public float rotationSpeed;
    private float angleToRotate;

    public float moveSpeed = 10f;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        LookDirection();
        MoveDirection();
    }
    void LookDirection(){
        Debug.Log("currentLookDir - " + currentLookDirection);
        directionToLook = (player.transform.position - transform.position).normalized;
        currentLookDirection = transform.forward;
        Debug.Log("pointToLook - " + directionToLook);
        angleToRotate = rotationSpeed / (directionToLook - currentLookDirection).magnitude;
        Quaternion interpolatedDirection = Quaternion.Slerp(Quaternion.LookRotation(currentLookDirection),Quaternion.LookRotation(directionToLook), angleToRotate);
        Debug.Log("interpolatedDirection - " + interpolatedDirection);
        transform.rotation = interpolatedDirection;
    }

    void MoveDirection(){
        float angleToMove = Mathf.Acos(Vector3.Dot(currentLookDirection, directionToLook)/(currentLookDirection.magnitude * directionToLook.magnitude));
        if((angleToMove < 20 * Mathf.Deg2Rad) || (currentLookDirection == directionToLook))
        {
            rb.velocity = currentLookDirection * moveSpeed;
        } 
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }
}