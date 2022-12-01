using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is a script for testing things
public class Scientist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Chassis vc = Resources.Load<GameObject>("Chassis/Fox").GetComponent<Chassis>();
        Instantiate(vc.gameObject);
    }
}
