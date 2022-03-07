using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private float speed = 50;
    [SerializeField] private GameObject bullet;
    [SerializeField] private PlayerMovement playerMovement;
    private float distanceFromPlayer = 2;
    private Vector3 firePoint;
    private Vector3 shootingDirection;
    private float delay = 0.05f;

    private float bulletDensity = 1f;
    private float period = 0;


    private void FixedUpdate()
    {
        DelaySet(); 
        period += Time.fixedDeltaTime;
        if(period >= delay){
            Fire();
            period = 0;
        }
    }
    void Update()
    {

    }
    void Fire()
    {
        shootingDirection = playerMovement.mouseDir ;
        shootingDirection.Normalize();
        firePoint = transform.position;
        firePoint += shootingDirection * distanceFromPlayer;
        GameObject bulletObj = Instantiate(bullet, firePoint, new Quaternion(0,0,0,0)) as GameObject; 
        bulletObj.GetComponent<Bullet>().BulletCreator(shootingDirection, speed);
    }

    void DelaySet()
    {
        float projection = Vector3.Dot(playerMovement.rb.velocity, 
                                       playerMovement.mouseDir.normalized * speed) / speed;
        delay = (1f + bulletDensity)/(speed - projection) ;
    }
}
