using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string weaponName;
    public int damage;
    public float maxRange;
    public float maxCoolDown;
    public float attackSpeed;
    public WeaponType weaponType;
    
    public enum WeaponType
    {
        Melee,
        Firearm,
        Automatic
    }
    
    public WeaponData(string name, int dmg, float range, float coolDown, float speed, WeaponType type)
    {
        weaponName = name;
        damage = dmg;
        maxRange = range;
        maxCoolDown = coolDown;
        attackSpeed = speed;
        weaponType = type;
    }
}
