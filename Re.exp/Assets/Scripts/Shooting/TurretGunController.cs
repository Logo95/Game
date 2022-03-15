using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunController : ShootingController
{
    private List<int> bulletSetter;
    private void Start()
    {
        bulletSetter = new List<int>();
        for(int i = 0; i < firePoints.Count;i++)
        {
            delays[i] = (bullets[0].transform.localScale.x + distanceBetweenShots)/(bulletSpeed);
            bulletSetter.Add(0);

        }
    }
    void FixedUpdate()
    {
        for(int i = 0; i < firePoints.Count;i++)
        {
            shotCounter[i] += Time.fixedDeltaTime;
            if (delays[i] < shotCounter[i])
            {
                bulletSetter[i] = (bulletSetter[i] + 1) % bullets.Count;
                Shoot(i, bulletSetter[i]);
                shotCounter[i] = 0;
            }
        }

    }
}
