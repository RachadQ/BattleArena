using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject playerPrefab;
    //Player spawn point
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the player locally
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void OnGUI()
    {
        // Show room info
        GUI.Label(new Rect(135, 5, 200, 25), "Arena - Single Player");

        // Show player info
        GUI.Label(new Rect(5, 35, 200, 25), "Player 1: Local Player");

        //leave this room
        if (GUI.Button(new Rect(5, 5, 125, 25), "Back to Menu"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
