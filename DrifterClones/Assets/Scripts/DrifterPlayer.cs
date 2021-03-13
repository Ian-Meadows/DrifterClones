using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimeInfo
{
    public float time;
    public float angle;
    public bool isThrusting;
    public Vector2 velocity;
    public Vector2 position;

    public TimeInfo(float time, float angle, bool isThrusting, Vector2 velocity, Vector2 position)
    {
        this.time = time;
        this.angle = angle;
        this.isThrusting = isThrusting;
        this.velocity = velocity;
        this.position = position;
    }
}



public class DrifterPlayer : Drifter
{
    private const float updateRate = 0.05f;
    public List<TimeInfo> info = new List<TimeInfo>();

    private bool canClick = false;

    protected override void StartUp()
    {
        AddInfo();
        InvokeRepeating("AddInfo", updateRate, updateRate);
        Invoke("RemoveClickDelay", 1f);
        canRecordTime = false;
    }

    protected override void Movement()
    {
        Rotate();
        if (Input.GetMouseButton(0) && canClick)
        {
            canRecordTime = true;
            StartSpeedUp();
        }
        else
        {
            StopSpeedUp();
        }

    }


    private void Rotate()
    {
        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }


    private void AddInfo()
    {
        if (canRecordTime)
        {
            info.Add(new TimeInfo(time, transform.eulerAngles.z, canSpeedUp, GetVelocity(), transform.position));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        FollowDrifter[] drifters = FindObjectsOfType<FollowDrifter>();
        foreach (FollowDrifter d in drifters)
        {
            Destroy(d.gameObject);
        }
        
        Destroy(gameObject);
    }

    private void RemoveClickDelay()
    {
        canClick = true;
    }

}
