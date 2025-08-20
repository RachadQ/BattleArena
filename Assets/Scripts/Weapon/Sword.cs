using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Melee
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("collided with " + WeapName);

            PC playerComponent = collision.gameObject.GetComponent<PC>();
            if (playerComponent != null)
            {
                playerComponent.SetWeapon(this);
            }

            Destroy(this.gameObject);
        }
    }
}
