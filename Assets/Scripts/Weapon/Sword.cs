using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Melee
{
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("collided with " + WeapName);

           
            collision.gameObject.GetComponent<PC>().SetWeapon(this);

            Destroy(this.gameObject);
        }
    }


}
