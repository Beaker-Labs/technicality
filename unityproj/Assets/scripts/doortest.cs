using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class doortest : MonoBehaviour
{
    public void TestDoors()
    {
        Debug.Log("gonna test the doors");
        FindObjectOfType<LoadingDoors>().CloseDoors(FinishDoorTest);
    }

    public void FinishDoorTest()
    {
        Debug.Log("doors have closed, freezing");
        Thread.Sleep(1000);
        Debug.Log("Unfreezing, doors opening");
    }
}
