using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;

    public float fireRate;
    private float distanceBetweenShots = 1.5f;
    private float shotCounter;

    private float delay;
    private float projection;
    private PlayerController player;


    public Transform firePoint;
    
    void Start()
    {
        player = gameObject.GetComponentInParent(typeof(PlayerController)) as PlayerController;
    }

    async void FixedUpdate(){

        projection = Vector3.Dot(player.rb.velocity, (player.pointToLook - player.transform.position).normalized * fireRate) / fireRate;
        delay = (bullet.transform.localScale.x + distanceBetweenShots)/(fireRate - projection);
        shotCounter += Time.fixedDeltaTime;

        if (delay < shotCounter){
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = fireRate;
            shotCounter = 0;
        }
    }

}
