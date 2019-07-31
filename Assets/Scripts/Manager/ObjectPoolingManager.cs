using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager 
{
    public static ObjectPoolingManager instance;

    public static Dictionary<int,ArenaManager> Lobbys = new Dictionary<int,ArenaManager>();

    //add arena
    public static void AddArena(ArenaManager arena)
    {
        Lobbys.Add(arena.id, arena);
        Debug.Log(Lobbys.Count);
    }

    public static void RemoveArena(ArenaManager arena)
    {
        Lobbys.Remove(arena.id);

    }
}
