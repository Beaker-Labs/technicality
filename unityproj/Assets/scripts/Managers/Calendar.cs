using System;
using TMPro;
using UnityEngine;

// Manager script for the calendar scene,
// where the player can check or go to upcoming tournaments
public class Calendar : MonoBehaviour
{
    public TextMeshProUGUI dateText;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    
    // OnEnable is called every time the gameobject is enabled
    void OnEnable()
    {
        int month = 1;//GameInfo.Campaign.Month;
        DateTime currentDate = GameInfo.StartDate.AddMonths(month);
        dateText.text = $"{currentDate.ToString("MMMM yyyy")}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
