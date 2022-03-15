using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : ShootingController
{
    private int bulletSetter = 0;
    private void Start()
    {
        for(int i = 0; i < firePoints.Count;i++)
        {
            delays[i] = (bullets[0].transform.localScale.x + distanceBetweenShots)/(bulletSpeed);
        }
    }
    void FixedUpdate()
    {
        for(int i = 0; i < firePoints.Count;i++)
        {
            shotCounter[i] += Time.fixedDeltaTime;
            if (delays[i] < shotCounter[i])
            {
                bulletSetter = (bulletSetter + 1) % bullets.Count;
                Shoot(i, bulletSetter);
                shotCounter[i] = 0;
            }
        }

    }
}
