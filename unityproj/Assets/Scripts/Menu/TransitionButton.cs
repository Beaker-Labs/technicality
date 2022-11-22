using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionButton : MonoBehaviour
{
    public GameObject destinationCanvas;
    
    public void Transition()
    {
        FindObjectOfType<LoadingDoors>().CloseDoors(FinishTransition);
    }

    private void FinishTransition()
    {
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        destinationCanvas.SetActive(true);
    }
}