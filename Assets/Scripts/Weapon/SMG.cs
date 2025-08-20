using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Automatic
{

    void Start()
    {
        WeapName = "SMG";
        MaxRange = 10;
        AttackSpeed = 500f;
        MaxCoolDown = 1f;
        CoolDown = 0.0f;
        SetType();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("clided");
            SMG gun = this;
            PC playerComponent = collision.gameObject.GetComponent<PC>();
            if (playerComponent != null)
            {
                playerComponent.SetWeapon(gun);
            }
        }
    }
}
