using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAI : MonoBehaviour
{
    ObjectType objectType;
    public float rotationSpeed;
    private float angleToRotate;
    public float enemyFOV = 20f;

    public float moveSpeed = 10f;
    private Vector3 directionToLook;
    private Rigidbody rb;
    MinerTargets MinerTargets;
    public List<Transform> path = new List<Transform>();
    private int pointCounter = 0; 
    [SerializeField] private MineController mine;

    private void Awake()
    {
        objectType = GetComponent<ObjectType>();
        rb = GetComponent<Rigidbody>();
        MinerTargets = FindObjectOfType<MinerTargets>();
        foreach (Transform child in MinerTargets.transform)
            path.Add(child);
    }

    void FixedUpdate()
    {
        if((transform.position - path[pointCounter].position).magnitude < 1)
        {
            Instantiate(mine,transform.position,transform.rotation);
            pointCounter = pointCounter + 1;
        }
        if(pointCounter == path.Count)
        {
            Object.Destroy(gameObject);
            return;
        }
        LookDirection(path[pointCounter]);
        MoveDirection();

    }

    void LookDirection(Transform target){
        directionToLook = (target.position - transform.position).normalized;
        angleToRotate = rotationSpeed / (directionToLook - transform.forward).magnitude;
        Quaternion interpolatedDirection = Quaternion.Slerp(Quaternion.LookRotation(transform.forward),Quaternion.LookRotation(directionToLook), angleToRotate);

        transform.rotation = interpolatedDirection;
    }

    void MoveDirection(){
        float angleToMove = Mathf.Acos(Vector3.Dot(transform.forward, directionToLook)/(transform.forward.magnitude * directionToLook.magnitude));
        if((angleToMove < enemyFOV * Mathf.Deg2Rad) || (transform.forward == directionToLook))
        {
            rb.velocity = transform.forward * moveSpeed;
        } 
        else
        {
            rb.velocity = Vector3.zero;
        }
        
    }
}
