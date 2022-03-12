using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector] public float speed;
    private float ttl = 3f;


    void FixedUpdate()
    {
        if (ttl <= 0) Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        ttl -= Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Object.Destroy(gameObject);
    }
}
