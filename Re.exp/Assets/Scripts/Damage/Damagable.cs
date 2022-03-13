using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int healthPoints = 100;
    public bool type;
    public void DamageDeal(int _damageTaken)
    {
        if (healthPoints <= _damageTaken)
        {
            Die();
        }
        else
        {
            healthPoints -= _damageTaken;
        }
    }

    private void Die(){
        gameObject.SetActive(false);
    }
}
