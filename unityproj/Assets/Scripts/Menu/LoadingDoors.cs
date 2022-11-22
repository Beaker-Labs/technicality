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

    void Awake()
    {
        GameInfo.LoadingDoors = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CloseDoors(Action onDoorsClosed)
    {
        _onDoorsClosed = onDoorsClosed;
        animator.SetTrigger("Close");
    }

    // This is called by the door closing animator once the doors have closed.
    public void DoorsClosed()
    {
        _onDoorsClosed();
        animator.SetTrigger("Open");
    }
}
