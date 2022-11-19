using System;
using UnityEngine;

// This is the manager script for the HQ scene. It is responsible for:
// - Sending the player to the Garage, Calendar, or Catalog scene when button is pressed
public class Headquarters : MonoBehaviour
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
