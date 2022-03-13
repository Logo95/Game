using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 10f;
    [SerializeField] List<Transform> firePoints;
    public BulletController bullet;
    public float delay = 0.1f;
    private float shotCounter;
    private Damager dm;
    public float bulletSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
        shotCounter += Time.fixedDeltaTime;
        if (delay < shotCounter){
            foreach(Transform i in firePoints){
                BulletController newBullet = Instantiate(bullet, i.position, i.rotation) as BulletController;
                dm = newBullet.GetComponent<Damager>();
                dm.type = true; 
                newBullet.speed = bulletSpeed;
                shotCounter = 0;
            }
            
        }
    }


}
