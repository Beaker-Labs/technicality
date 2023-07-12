using System;
using TMPro;
using UnityEngine;

// This is the manager script for the HQ scene. It is responsible for:
// - Sending the player to the Garage, Calendar, or Catalog scene when button is pressed
public class Headquarters : MonoBehaviour
{
    public TextMeshProUGUI cashText;

    private BattleTeam _battleTeam = new BattleTeam();
    
    void Awake()
    {
        GameInfo.Headquarters = this;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // OnEnable is called when the object is enabled
    // for this script that happens when the player switches to the HQ screen 
    void OnEnable()
    {
        cashText.text = "Funds: $" + GameInfo.Campaign.Cash;
        _battleTeam = GameInfo.Campaign.GetBattleTeam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 160, 220));
        GUILayout.BeginVertical("Team Info", GUI.skin.box);
        GUILayout.Space(20);
        for (int i = 0; i < _battleTeam.Vehicles.Count; i++)
        {
            Vehicle v = _battleTeam.Vehicles[i];
            GUILayout.Label($"{v.Name}\n  Wt: {v.GetWeight()}  HP: {v.GetMaxHitPoints()}");
            GUILayout.Space(10);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
