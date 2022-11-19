using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingDoors : MonoBehaviour
{
    public Animator animator;
    private bool _closing;
    private int _toLoad;
    private Action _onDoorsClosed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CloseDoors(Action ondoorsClosed)
    {
        _onDoorsClosed = ondoorsClosed;
        animator.SetTrigger("Close");
    }

    public void DoorsClosed()
    {
        _onDoorsClosed();
        animator.SetTrigger("Open");
    }
}
