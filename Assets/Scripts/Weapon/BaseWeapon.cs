using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int WielderId;
    public string WeapName { get; set; }
    public int Damage { get; set; }
    public float MaxCoolDown { get; set; }
    public float CoolDown { get; set; }
    public float MaxRange { get; set; }
    public float AttackSpeed { get; set; }

    public virtual void UseWeapon(Vector3 direction)
    {


        Debug.Log("base attacking");
        
    }

    public virtual void UseWeapon(Transform container)
    {

        Debug.Log("base attacking gun");


    }



    public virtual void SetWeaponlocation(GameObject container)
    {

        //make a copy of weapon
        GameObject temp = this.gameObject;
       
        temp.transform.position = Vector3.zero;
        //if already have weapon delete it
        if (container.transform.childCount > 0)
        {
            
          
            Destroy(container.transform.GetChild(0).gameObject);
          
           
        }
        temp.GetComponent<Collider>().enabled = false;

        temp = Instantiate(temp, Vector3.zero, Quaternion.identity, container.transform) as GameObject;
       
        temp.transform.localPosition = Vector3.zero;
     
      
    }
   

 

}
