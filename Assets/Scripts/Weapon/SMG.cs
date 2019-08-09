using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("clided");
            SMG gun = this;
            collision.gameObject.GetComponent<PC>().SetWeapon(gun);
           // PhotonNetwork.Destroy(this.gameObject);
            //  collision.transform.GetComponent<PhotonView>().RPC("SetWeapon", Photon, gun);
       
           
          
        }
    }



}
