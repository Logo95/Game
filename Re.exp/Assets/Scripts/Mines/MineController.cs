using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    private int damage;

    private void OnTriggerEnter(Collider other)
    {
        ObjectType otherObjType = other.GetComponent<ObjectType>();
        if (otherObjType.type == ObjectType.Type.Player){
            Object.Destroy(gameObject);
        }
    }
}
