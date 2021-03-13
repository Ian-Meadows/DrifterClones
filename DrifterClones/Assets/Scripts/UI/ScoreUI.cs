using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

    Text text;

    FinishLine fl;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        fl = FindObjectOfType<FinishLine>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + fl.score;
    }
}
