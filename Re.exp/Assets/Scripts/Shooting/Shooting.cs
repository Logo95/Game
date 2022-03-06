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
    private float delay = 5;

    public float fireRate = 0.05f;
    private float period = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DelaySet();
        period += Time.deltaTime;
        if(period > delay){
            Fire();
            period = 0;
        }
    }
    void Fire()
    {
        shootingDirection = playerMovement.mouseDir ;
        shootingDirection.Normalize();
        firePoint = new Vector3(transform.position.x,
                                transform.position.y, 
                                transform.position.z);
        firePoint += shootingDirection * distanceFromPlayer;
        GameObject bulletObj = Instantiate(bullet, firePoint, new Quaternion(0,0,0,0)) as GameObject; 
        bulletObj.GetComponent<Bullet>().BulletCreator(shootingDirection, speed );
    }

    void DelaySet()
    {
        float projection = Vector3.Dot(playerMovement.moveDirection * playerMovement.moveSpeed, 
                                       playerMovement.mouseDir.normalized * speed) / speed;
        delay = (1f + fireRate)/(speed - projection) ;
    }
}
