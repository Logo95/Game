using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int healthPoints = 100;
   public ObjectType objectType;

    private void Start()
    {
        objectType = GetComponent<ObjectType>();
    }

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
        
        switch (objectType.type)
        {
            case (ObjectType.Type.EnemyMob):
            {
                //enemy die event
                ObjectType.Destroy(gameObject);
                break;
            }
            case (ObjectType.Type.Player):
            {
                //player die event
                gameObject.SetActive(false);
                break;
            }
            default:
            {
                ObjectType.Destroy(gameObject);
                break;
            }
        }

    }
}
