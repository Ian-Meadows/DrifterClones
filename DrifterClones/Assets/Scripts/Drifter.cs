using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifter : MonoBehaviour
{

    protected const float speed = 0.2f;

    private Thruster thruster;

    protected Rigidbody2D rb;

    protected bool canSpeedUp { get; private set; }

    protected float time = 0f;

    protected bool canRecordTime = true;

    public bool firstLap = true;
    public bool hasLeftStart = true;

    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        canSpeedUp = false;
        rb = GetComponent<Rigidbody2D>();
        thruster = GetComponentInChildren<Thruster>();

        StartUp();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canRecordTime)
        {
            time += Time.deltaTime;
        }
        Movement();
        if (canSpeedUp)
        {
            SpeedUp();
        }
    }

    protected virtual void StartUp()
    {

    }

    protected virtual void Movement()
    {

    }

    private void SpeedUp()
    {
        rb.velocity += new Vector2(speed * transform.up.x, speed * transform.up.y);
    }

    protected void StartSpeedUp()
    {
        canSpeedUp = true;
        thruster.ShowThruster();
    }

    protected void StopSpeedUp()
    {
        canSpeedUp = false;
        thruster.DontShowThruster();
    }

    protected Vector2 GetVelocity()
    {
        return rb.velocity;
    }

    protected void SetVelocity(Vector2 vel)
    {
        rb.velocity = vel;
    }

    protected void OnDestroy()
    {
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 5);
    }

}
