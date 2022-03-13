using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableBulletController : BulletController
{
    private Damager dmOther;
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
            Debug.Log("123");
            if(other.TryGetComponent(out Damager dmOther))
            {
                dm = GetComponent<Damager>();
                if (dmOther.type != dm.type)
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
