using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : ShootingController
{


    private EnemyAI enemy;
    private Rigidbody enemyRb;

    
    void Start()
    {
        enemy = gameObject.GetComponentInParent(typeof(EnemyAI)) as EnemyAI;
        enemyRb = gameObject.GetComponentInParent<Rigidbody>();
        DelaySet(enemyRb);
    }

    void FixedUpdate(){
        
        shotCounter[0] += Time.fixedDeltaTime;
        if (delays[0] < shotCounter[0]){
            Shoot();
            DelaySet(enemyRb);
            shotCounter[0] = 0;
        }
    }
    

}
