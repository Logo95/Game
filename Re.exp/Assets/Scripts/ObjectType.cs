using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType: MonoBehaviour
{
    public enum Type
    {
        Player,
        EnemyMob,
        Bullet,
        Obstacle,
        Mine 
    }

    public enum Essence
    {
        Enemy,
        Ally,
        Neutral
    }

    
    public Essence essence;
    public Type type;
    public string objName;
    public string description;


}
