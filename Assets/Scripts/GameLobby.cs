using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLobby : MonoBehaviour
{
    //Player Name
    string playerName = "Player 1";
    string roomName = "Room 1";

    // Start is called before the first frame update
    void Start()
    {
        // No networking setup needed for single player
    }

    private void OnGUI()
    {
        GUI.Window(0, new Rect(Screen.width / 2 - 450, Screen.height / 2 - 200, 900, 400), LobbyWindow, "Lobby");
    }

    void LobbyWindow(int index)
    {
        //connection status and Room creation button
        GUILayout.BeginHorizontal();
        GUILayout.Label("Status: Connected (Single Player)");

        GUILayout.FlexibleSpace();
        //Room name text field
        roomName = GUILayout.TextField(roomName, GUILayout.Width(250));

        if (GUILayout.Button("Start Game", GUILayout.Width(125)))
        {
            if (roomName != "")
            {
                // Load the Arena scene directly
                UnityEngine.SceneManagement.SceneManager.LoadScene("Arena");
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Player Name", GUILayout.Width(85));
        //player name text field
        playerName = GUILayout.TextField(playerName, GUILayout.Width(250));

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Refresh", GUILayout.Width(100)))
        {
            // No action needed for single player
        }

        GUILayout.EndHorizontal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
