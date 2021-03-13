using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDrifter : Drifter
{

    public DrifterPlayer dp;

    

    int index = 0;

    protected override void StartUp()
    {
        TryUpdate();
    }

    protected override void Movement()
    {
        TryUpdate();
    }


    private void TryUpdate()
    {
        if (index >= dp.info.Count)
        {
            print("Out of array");
            return;
        }
        TimeInfo ti = dp.info[index];

        if (ti.time <= time)
        {
            ++index;

            transform.position = ti.position;
            transform.rotation = Quaternion.Euler(0, 0, ti.angle);
            if (ti.isThrusting)
            {
                StartSpeedUp();
            }
            else
            {
                StopSpeedUp();
            }

            SetVelocity(ti.velocity);
        }
    }

}
