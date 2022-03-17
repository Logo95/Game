using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public float speed;
    private float ttl = 3f;
    protected Damager dm;
    public ObjectType objectType;

    void FixedUpdate()
    {
        if (ttl <= 0) Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        ttl -= Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectType otherObjectType))
        {
            objectType = GetComponent<ObjectType>();
            if(objectType.essence != otherObjectType.essence)
            {
                if(otherObjectType.type != ObjectType.Type.Bullet)
                {
                    Object.Destroy(gameObject);
                }
                else
                {
                    if(!TryGetComponent(out Damagable otherDmble))
                    {
                        Object.Destroy(gameObject);
                    }
                }         
            }
        }
        else
        {
            Object.Destroy(gameObject); 
        }
    }
}
