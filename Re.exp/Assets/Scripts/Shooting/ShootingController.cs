using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public BulletController bullet;
    public float bulletSpeed;
    protected float shotCounter;
    public float delay;
    protected Damager dm;
    public bool type;

    protected void Shoot(Transform firePoint){
        BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
        dm = newBullet.GetComponent<Damager>();
        dm.type = type; 
        newBullet.speed = bulletSpeed;
        shotCounter = 0;
    }
}
