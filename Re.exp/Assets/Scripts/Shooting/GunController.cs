using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;

    public float bulletSpeed;
    public float distanceBetweenShots = 1.5f;
    private float shotCounter;

    private float delay;
    private float projection;
    private PlayerController player;
    private Vector3 lookDir;

    public Transform firePoint;

    private Damager dm;
    
    void Start()
    {
        player = gameObject.GetComponentInParent(typeof(PlayerController)) as PlayerController;

        DelaySet();
    }

    void FixedUpdate(){
        
        shotCounter += Time.fixedDeltaTime;
        if (delay < shotCounter){
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            dm = newBullet.GetComponent<Damager>();
            dm.type = true; 
            newBullet.speed = bulletSpeed;
            DelaySet();
            shotCounter = 0;
        }
    }
    void DelaySet(){
        //Debug.Log(player.pointToLook);
        lookDir = player.pointToLook - firePoint.position;
        lookDir.y = firePoint.position.y;
        Vector3 vel = player.rb.velocity;
        vel.y = firePoint.position.y;
        projection = Vector3.Dot(vel, lookDir.normalized * bulletSpeed) / bulletSpeed;
        delay = (bullet.transform.localScale.x + distanceBetweenShots)/(bulletSpeed - projection);
    }

}
