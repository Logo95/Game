using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   public int damage = 1;
   private Damagable damagable = null;
   public bool type;
   private void OnTriggerEnter(Collider other)
   {
      damagable = other.gameObject.GetComponent<Damagable>();
      if ((damagable != null) && (damagable.type != type)){
         damagable.DamageDeal(damage);
      }
   }
}
