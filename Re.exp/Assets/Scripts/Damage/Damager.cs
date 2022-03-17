using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
   public int damage = 1;
   private Damagable damagable = null;
   public ObjectType objectType;
   private void Start()
   {
      objectType = GetComponent<ObjectType>();
   }
   private void OnTriggerEnter(Collider other)
   {
      damagable = other.gameObject.GetComponent<Damagable>();
      if ((damagable != null) && (damagable.objectType.essence != objectType.essence)){
         damagable.DamageDeal(damage);
      }
   }
   private void OnCollisionEnter(Collision other){
      damagable = other.gameObject.GetComponent<Damagable>();
      if ((damagable != null) && (damagable.objectType.essence != objectType.essence))
      damagable.DamageDeal(damage);
   }


}
