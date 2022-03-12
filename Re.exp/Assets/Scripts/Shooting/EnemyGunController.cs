using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{

    public BulletController bullet;

    public float fireRate;
    private float distanceBetweenShots = 1.5f;
    private float shotCounter;

    private float delay;
    private float projection;
    private EnemyAI enemy;
    private Vector3 lookDir;
    private Rigidbody enemyRb;

    public Transform firePoint;
    
    void Start()
    {
        enemy = gameObject.GetComponentInParent(typeof(EnemyAI)) as EnemyAI;
        enemyRb = gameObject.GetComponentInParent<Rigidbody>();
        DelaySet();
    }

    void FixedUpdate(){
        
        shotCounter += Time.fixedDeltaTime;
        if (delay < shotCounter){
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = fireRate;
            DelaySet();
            shotCounter = 0;
        }
    }
    void DelaySet(){
        lookDir = enemy.currentLookDirection - firePoint.position;
        lookDir.y = firePoint.position.y;
        Vector3 vel = enemyRb.velocity;
        vel.y = firePoint.position.y;
        projection = Vector3.Dot(vel, lookDir.normalized * fireRate) / fireRate;
        delay = (bullet.transform.localScale.x + distanceBetweenShots)/(fireRate - projection);
    }

}
