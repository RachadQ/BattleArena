using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;       
public class RoomController : MonoBehaviourPunCallbacks
{
  
    public GameObject playerPrefab;
    //Player spawn point
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
       if ( PhotonNetwork.CurrentRoom == null)
        {

            Debug.Log("is not in the room, returning back to lobby");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity, 0);
    }


    private void OnGUI()
    {
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        //leave this room
        if (GUI.Button(new Rect(5,5,125,25), "Leave Room"))
        {
            PhotonNetwork.LeaveRoom();
        }

        // Show the room name   
        GUI.Label(new Rect(135, 5, 200, 25), PhotonNetwork.CurrentRoom.Name);

        //show players connected
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            //and show if master client
            string isMasterClient = (PhotonNetwork.PlayerList[i].IsMasterClient ? ": MasterClient" : "");
            GUI.Label(new Rect(5, 35 + 30 * i, 200, 25),PhotonNetwork.PlayerList[i].NickName + isMasterClient);
        }
    }

    public override void OnLeftRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
