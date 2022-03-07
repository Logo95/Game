using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 speedVector;
    private Vector3 direction;
    private bool hit;
    private SphereCollider sphereCollider;
    private float lifetime;
    //private Animator anim;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        //anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if(hit) return;
        transform.Translate(speedVector);
        lifetime += Time.deltaTime;
        if (lifetime > 3) Deactivate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Bullet"){
        hit = true;
        //anim.SetTrigger("explode");
        Deactivate();// нужно деактивировать в конце анимации
        }
        
    }
    public void BulletCreator(Vector3 _direction, float _speed)
    {
        direction = _direction;
        hit = false;
        lifetime = 0;
        speedVector = _speed * Time.deltaTime * direction;
       
    }
    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
