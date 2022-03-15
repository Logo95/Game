using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] public List<BulletController> bullets;
    [SerializeField] public List<Transform> firePoints;
    public float bulletSpeed;
    [SerializeField] public List<float> shotCounter;
    [SerializeField] public List<float> delays;
    protected Damager dm;
    public bool type;
    private Vector3 lookDir;
    private float projection;
    public float distanceBetweenShots = 1.5f;

    protected void Shoot(int _firePoint = 0, int _bullet = 0){
        BulletController newBullet = Instantiate(bullets[_bullet], firePoints[_firePoint].position, firePoints[_firePoint].rotation) as BulletController;
        dm = newBullet.GetComponent<Damager>();
        dm.type = type; 
        newBullet.speed = bulletSpeed;
    }
    public void DelaySet(Rigidbody rb, int _firePoint = 0, int _bullet = 0){
        lookDir = rb.transform.forward;
        lookDir.y = firePoints[_firePoint].position.y;
        Vector3 vel = rb.velocity;
        vel.y = firePoints[_firePoint].position.y;
        projection = Vector3.Dot(vel, lookDir * bulletSpeed) / bulletSpeed;
        delays[_firePoint] = (bullets[_bullet].transform.localScale.x + distanceBetweenShots)/(bulletSpeed - projection);
    }

    
}
