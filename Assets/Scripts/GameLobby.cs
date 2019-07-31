using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class GameLobby : MonoBehaviourPunCallbacks​
{
    //Player Name
    string playerName = "Player 1";
    //seperate by game version
    string gameVersion = "0.9";
    //list of created rooms
    List<RoomInfo> createdRooms = new List<RoomInfo>();
    string roomName = "Room 1";
    Vector2 roomListScroll = Vector2.zero;
    bool joiningRoom = false;


    // Start is called before the first frame update
    void Start()
    {
        //sync level automatically
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnected)
        {
            //set app version
            PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnFailedToConnectToPhoton. StatusCode" + cause.ToString() + "ServerAddress: " + PhotonNetwork.ServerAddress);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        //after connects to server join lobby
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("We Have recieved the room List");
        //update room list
        createdRooms = roomList;
    }

    private void OnGUI()
    {
        GUI.Window(0, new Rect(Screen.width / 2 - 450, Screen.height / 2 - 200, 900, 400), LobbyWindow, "Lobby");

    }

    void LobbyWindow(int index)
    {
        //connection tatus and Room creation button
        GUILayout.BeginHorizontal();
        GUILayout.Label("Status: " + PhotonNetwork.NetworkClientState);
        Debug.Log(PhotonNetwork.NetworkClientState + " " + PhotonNetwork.IsConnected  + joiningRoom);

        if (joiningRoom || !PhotonNetwork.IsConnected || PhotonNetwork.NetworkClientState != ClientState.JoinedLobby)
        {
            GUI.enabled = false;
        }
        GUILayout.FlexibleSpace();
        //Room name text field
        roomName = GUILayout.TextField(roomName, GUILayout.Width(250));

        if (GUILayout.Button("Create Room", GUILayout.Width(125)))
        {
            if (roomName != "")
            {
                joiningRoom = true;

                RoomOptions roomOptions = new RoomOptions();
                roomOptions.IsOpen = true;
                roomOptions.IsVisible = true;
                roomOptions.MaxPlayers = (byte)10; //Set any number

                PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
            }
        }


        GUILayout.EndHorizontal();
        //scroll through avaiable room
        roomListScroll = GUILayout.BeginScrollView(roomListScroll, true, true);
        

        if (createdRooms.Count == 0)
              {
                  GUILayout.Label("No rooms were created yet");
              }
              else
              {
                  //loop through room
                  for (int i = 0; i < createdRooms.Count; i++)
                  {
                      GUILayout.BeginHorizontal("box");
                      GUILayout.Label(createdRooms[i].PlayerCount + "/" + createdRooms[i].MaxPlayers);

                      GUILayout.FlexibleSpace();

                      if (GUILayout.Button("join Room"))
                      {
                          joiningRoom = true;

                          //set player name
                          PhotonNetwork.NickName = playerName;

                          //join room
                          PhotonNetwork.JoinRoom(createdRooms[i].Name);

                      }

                      GUILayout.EndHorizontal();
                  }

              }


              GUILayout.EndScrollView();

              GUILayout.BeginHorizontal();
              GUILayout.Label("Player Name", GUILayout.Width(85));
              //player name text field
              playerName = GUILayout.TextField(playerName, GUILayout.Width(250));

              GUILayout.FlexibleSpace();

        GUI.enabled = (PhotonNetwork.NetworkClientState == ClientState.JoinedLobby || PhotonNetwork.NetworkClientState == ClientState.Disconnected) && !joiningRoom;

        if (GUILayout.Button("Refresh",GUILayout.Width(100)))
              {
                  if (PhotonNetwork.IsConnected)
                  {
                      //Re-join lobby to get the latest room list
                      PhotonNetwork.JoinLobby(TypedLobby.Default);
                  }
                  else
                  {
                      //not connected establish new connection
                      PhotonNetwork.ConnectUsingSettings();
                  }
              }

              GUILayout.EndHorizontal();

              if (joiningRoom)
              {
                  GUI.enabled = true;
                  GUI.Label(new Rect(900 / 2 - 50, 400 / 2 - 10, 100, 20), "Connecting");
              }
              
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
        joiningRoom = false;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
        joiningRoom = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed got called. This can happen if the room is not existing or full or closed.");
        joiningRoom = false;
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        //Set our player name
        PhotonNetwork.NickName = playerName;
        //Load the Scene called GameLevel (Make sure it's added to build settings)
        PhotonNetwork.LoadLevel("Arena");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
