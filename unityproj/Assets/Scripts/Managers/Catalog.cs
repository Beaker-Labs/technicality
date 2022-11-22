using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalog : MonoBehaviour
{
    void Awake()
    {
        GameInfo.Catalog = this;
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
