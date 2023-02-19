using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : DefaultShip
{
    protected Transform PlayerTransform {get; set;}
    protected Vector3   PlayerDirection {get; set;}
    protected List<Sensor> Sensors {get; set;}

    protected void UpdateDirection()
    {
        if (!Sensors[0].Active && !Sensors[1].Active)
        {
            Stunned = false;
            PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
            PlayerDirection = (PlayerTransform.position-transform.position).normalized;

            transform.up = Vector3.Lerp(transform.up, PlayerDirection, 2*Time.deltaTime);
        }
        else
        {
            Stunned = true;
            if (Sensors[0].Active && !Sensors[1].Active)
                Rudder(-CurveRadius);
            else if (!Sensors[0].Active && Sensors[1].Active)
                Rudder(CurveRadius);

        }
    }
}
