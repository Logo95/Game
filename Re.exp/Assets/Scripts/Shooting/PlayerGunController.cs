using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : ShootingController
{


    [SerializeField] private PlayerController player;
    void Start()
    {   
        DelaySet(player.rb);
    }

    void FixedUpdate(){
        
        shotCounter[0] += Time.fixedDeltaTime;
        if (delays[0] < shotCounter[0]){
            Shoot();
            DelaySet(player.rb);
            shotCounter[0] = 0;
        }
    }


}
