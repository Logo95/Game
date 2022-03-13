using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 10f;
    
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }


}
