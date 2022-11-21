using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyRoom : MonoBehaviour
{
    void Awake()
    {
        GameInfo.TrophyRoom = this;
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
