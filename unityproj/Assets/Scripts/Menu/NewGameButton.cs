using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    public GameObject destinationCanvas;
    
    public void PlayGame()
    {
        GameInfo.CloseLoadingDoors(LoadHQ);
    }

    private void LoadHQ()
    {
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        destinationCanvas.SetActive(true);
    }
}
