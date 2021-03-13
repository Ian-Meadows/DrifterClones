using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public DrifterPlayer dp;

    public FollowDrifter fdPrefab;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dp == null)
        {
            dp = FindObjectOfType<DrifterPlayer>();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Drifter drifter = collision.GetComponent<Drifter>();
        if (drifter != null && drifter.hasLeftStart)
        {
            ++score;
            drifter.hasLeftStart = false;
            
        }

        
        if (drifter != null && drifter.firstLap)
        {
            SpawnNewDrifter();
            drifter.firstLap = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Drifter drifter = collision.GetComponent<Drifter>();
        if (drifter != null && !drifter.hasLeftStart)
        {
            drifter.hasLeftStart = true;
        }
    }


    private void SpawnNewDrifter()
    {
        FollowDrifter newFD = Instantiate(fdPrefab, transform.position, Quaternion.identity);

        newFD.dp = dp;


    }

}
