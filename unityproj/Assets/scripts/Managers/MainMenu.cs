using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Make sure that GameInfo is constructed frame one.
        // This is kinda shitty
        Debug.Log(GameInfo.TournamentSeries[0].Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
