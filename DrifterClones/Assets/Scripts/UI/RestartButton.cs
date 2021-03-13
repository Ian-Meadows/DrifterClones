using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    DrifterPlayer dp;
    Button button;
    Image image;
    Text text;

    public DrifterPlayer dpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dp = FindObjectOfType<DrifterPlayer>();
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        image = GetComponent<Image>();

        button.enabled = false;
        image.enabled = false;
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dp == null)
        {
            button.enabled = true;
            image.enabled = true;
            text.enabled = true;
        }
    }


    public void Clicked()
    {

        FindObjectOfType<FinishLine>().score = 0;

        dp = Instantiate(dpPrefab);
        button.enabled = false;
        image.enabled = false;
        text.enabled = false;
    }
}
