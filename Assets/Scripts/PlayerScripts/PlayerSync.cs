using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSync : MonoBehaviour
{
    public MonoBehaviour[] localScripts;
    public GameObject[] localObjects;

    // Start is called before the first frame update
    void Start()
    {
        // All scripts and objects are enabled for local player
        for (int i = 0; i < localScripts.Length; i++)
        {
            localScripts[i].enabled = true;
        }

        for (int i = 0; i < localObjects.Length; i++)
        {
            localObjects[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No network synchronization needed for local player
    }
}
