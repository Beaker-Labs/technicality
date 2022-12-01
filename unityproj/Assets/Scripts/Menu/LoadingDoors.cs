using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingDoors : MonoBehaviour
{
    public Animator animator;
    private bool _closing;
    private Action _onDoorsClosed;

    void Awake()
    {
        GameInfo.LoadingDoors = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Call this to initiate the door closing animation, and pass a function to be executed when the doors close.
    public void CloseDoors(Action onDoorsClosed)
    {
        _closing = true;
        _onDoorsClosed = onDoorsClosed;
        animator.SetTrigger("Close");
    }

    // This is called by the door closing animator once the doors have closed.
    // Please don't call this
    public void DoorsClosed()
    {
        _closing = false;
        _onDoorsClosed();
        animator.SetTrigger("Open");
    }
    
    // returns true while the doors closing animation is playing
    public bool AreDoorsClosing()
    {
        return _closing;
    }
}
