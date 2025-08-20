using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : BaseWeapon
{

    public Ammunition ammo;
    public GameObject ammoPrefab; // Reference to the ammo prefab

    public void SetType()
    {
        if (ammo == null && ammoPrefab != null)
        {
            if (this is FireArms)
            {
                // Instantiate the ammo prefab and get the component
                GameObject ammoGO = Instantiate(ammoPrefab);
                ammo = ammoGO.GetComponent<Ammunition>();
                if (ammo == null)
                {
                    ammo = ammoGO.AddComponent<Bullet>();
                }
            }
        }

        if (ammo != null)
        {
            ammo.MaxRange = MaxRange;
            ammo.BulletSpeed = AttackSpeed;
            Debug.Log(ammo.MaxRange + " " + ammo.BulletSpeed);
        }
    }


    public override void UseWeapon( Transform container)
    {
        if (ammo == null) return;

        Vector3 shootLocation = container.position;
        //  container.position = container.forward; 

        GameObject obj = Instantiate(ammo.gameObject, shootLocation , container.rotation);

        UnityEngine.Rigidbody rb = obj.GetComponent<UnityEngine.Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(container.forward * AttackSpeed);
        }
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
