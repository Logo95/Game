using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : ShootingController
{
    private float projection;
    public float distanceBetweenShots = 1.5f;
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
            Shoot(firePoint);
            DelaySet();
        }
    }
    void DelaySet(){
        lookDir = enemy.currentLookDirection - firePoint.position;
        lookDir.y = firePoint.position.y;
        Vector3 vel = enemyRb.velocity;
        vel.y = firePoint.position.y;
        projection = Vector3.Dot(vel, lookDir.normalized * bulletSpeed) / bulletSpeed;
        delay = (bullet.transform.localScale.x + distanceBetweenShots)/(bulletSpeed - projection);
    }

}
