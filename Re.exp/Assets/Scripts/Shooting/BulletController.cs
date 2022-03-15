using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public float speed;
    private float ttl = 3f;
    protected Damager dm;

    void FixedUpdate()
    {
        if (ttl <= 0) Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        ttl -= Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Damagable dmble))
        {
            dm = GetComponent<Damager>();
            if( dmble.type != dm.type)
            {
                Object.Destroy(gameObject);         
            }
        }
        else
        {
            if(other.TryGetComponent(out Damager otherDm))
            {
                dm = GetComponent<Damager>();
                if( otherDm.type != dm.type)
                {
                   Object.Destroy(gameObject);         
                }
            }
            else
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
