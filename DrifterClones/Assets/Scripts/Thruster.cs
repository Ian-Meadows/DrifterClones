using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    public void ShowThruster()
    {
        if (sr != null)
        {
            sr.enabled = true;
        }
        
    }

    public void DontShowThruster()
    {
        if (sr != null)
        {
            sr.enabled = false;
        }
        
    }
}
