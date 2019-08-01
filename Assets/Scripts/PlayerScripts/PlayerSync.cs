using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerSync : MonoBehaviourPun, IPunObservable
{
    public MonoBehaviour[] localScripts;
    public GameObject[] localObjects;
    //values sync over network
    Vector3 latestPos;
    Vector3 latestRot;
    

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //this is our player: send others the data;
            stream.SendNext(transform.position);
            stream.SendNext(transform.GetChild(0).forward);
        }
        else
        {
            //network player recieve data
            latestPos = (Vector3)stream.ReceiveNext();
            latestRot = (Vector3)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            //player is local
        }
        else
        {
            
            //player is remote, deactivate the scripts and object that should only be activated for local player
            for (int i = 0; i < localScripts.Length; i++)
            {
                localScripts[i].enabled = false;
            }

            for (int i = 0; i < localObjects.Length; i++)
            {
                localObjects[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update remote player
        if (!photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, latestPos, Time.deltaTime * 5);
            Debug.Log(transform.GetChild(0).name);
            transform.GetChild(0).transform.forward = latestRot;//Quaternion.Lerp(transform.GetChild(0).rotation, latestRot, Time.deltaTime * 10);

        }
    }
}
