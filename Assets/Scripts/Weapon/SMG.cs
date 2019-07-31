using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Automatic
{

    public SMG()
    {
        WeapName = "SMG";
        MaxRange = 10;
        AttackSpeed = 500f;
        MaxCoolDown = 1f;
        CoolDown = 0.0f;
        SetType();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SMG gun = this;
            collision.gameObject.GetComponent<PC>().SetWeapon(gun);
            Destroy(this.gameObject);
        }
    }



}
