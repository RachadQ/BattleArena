using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : BaseWeapon
{

    public Ammunition ammo;

    public void SetType()
    {
        if (ammo == null)
        {

            if (this is FireArms)
            {
                ammo = new Bullet();
            }
        }

        ammo.MaxRange = MaxRange;
        ammo.BulletSpeed = AttackSpeed;
        Debug.Log(ammo.MaxRange + " " + ammo.BulletSpeed);
    }


    public override void UseWeapon( Transform container)
    {

       

        Vector3 shootLocation = container.position;
        //  container.position = container.forward; 


        GameObject obj = Instantiate(ammo.gameObject, shootLocation , container.rotation);


        obj.GetComponent<Rigidbody>().AddForce(container.forward * AttackSpeed);    
        Debug.Log("base attacking guns 2");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
