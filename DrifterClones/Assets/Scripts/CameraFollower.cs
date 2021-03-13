﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public DrifterPlayer dp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dp != null)
        {
            transform.position = dp.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
            dp = FindObjectOfType<DrifterPlayer>();
        }
    }
}