using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    public GameObject destinationCanvas;
    
    public void PlayGame()
    {
        FindObjectOfType<LoadingDoors>().CloseDoors(LoadHQ);
    }

    public void LoadHQ()
    {
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        destinationCanvas.SetActive(true);
    }
}
