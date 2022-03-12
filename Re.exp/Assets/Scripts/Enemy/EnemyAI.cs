using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    private PlayerController player;
    private Vector3 directionToLook;
    [HideInInspector] public Vector3 currentLookDirection;
    public float rotationSpeed;
    private float angleToRotate;
    private float enemyFOV = 20f;

    public float moveSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
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
        if((angleToMove < enemyFOV * Mathf.Deg2Rad) || (currentLookDirection == directionToLook))
        {
            rb.velocity = currentLookDirection * moveSpeed;
        } 
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }
}