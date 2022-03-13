using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : ShootingController
{

    private float projection;
    public float distanceBetweenShots = 1.5f;
    private PlayerController player;
    private Vector3 lookDir;
    public Transform firePoint;


    
    void Start()
    {   
        player = gameObject.GetComponentInParent(typeof(PlayerController)) as PlayerController;
        DelaySet();
    }

    void FixedUpdate(){
        
        shotCounter += Time.fixedDeltaTime;
        if (delay < shotCounter){
            Shoot(firePoint);
            DelaySet();
        }
    }
    private void DelaySet(){
        lookDir = player.pointToLook - firePoint.position;
        lookDir.y = firePoint.position.y;
        Vector3 vel = player.rb.velocity;
        vel.y = firePoint.position.y;
        projection = Vector3.Dot(vel, lookDir.normalized * bulletSpeed) / bulletSpeed;
        delay = (bullet.transform.localScale.x + distanceBetweenShots)/(bulletSpeed - projection);
    }

}
