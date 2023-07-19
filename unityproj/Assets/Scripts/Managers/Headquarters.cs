using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

// This is the manager script for the HQ scene. It is responsible for:
// - Sending the player to the Garage, Calendar, or Catalog scene when button is pressed
public class Headquarters : MonoBehaviour
{
    //public TextMeshProUGUI cashText;
    private UIDocument _uiDocument;

    private BattleTeam _battleTeam = new BattleTeam();
    private Canvas _canvas;
    
    void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
        _canvas = GetComponent<Canvas>();
        GameInfo.Headquarters = this;
        //gameObject.SetActive(false);
        
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public void Activate()
    {
        //cashText.text = "Funds: $" + GameInfo.Campaign.Cash;
        _battleTeam = GameInfo.Campaign.GetBattleTeam();
        _uiDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        GetComponent<Calendar>().Activate();
    }

    public void Deactivate()
    {
        _uiDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
}
