using System;
using Unity;
using UnityEngine;

// This is the manager script for the battle scene, and is responsible for:
// - loading the map
// - spawning in all the relevant teams
// - detecting when a team wins the battle, and notifying the tournament manager
//
public class BattleManager : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
