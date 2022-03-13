using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : ShootingController
{
    [SerializeField] List<Transform> firePoints;

    void FixedUpdate()
    {
        shotCounter += Time.fixedDeltaTime;
        if (delay < shotCounter){
            foreach(Transform i in firePoints){
                Shoot(i);
            }
        }
    }
}
