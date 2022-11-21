using System;
using TMPro;
using UnityEngine;

// This is the manager script for the HQ scene. It is responsible for:
// - Sending the player to the Garage, Calendar, or Catalog scene when button is pressed
public class Headquarters : MonoBehaviour
{
    public TextMeshProUGUI cashText;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
