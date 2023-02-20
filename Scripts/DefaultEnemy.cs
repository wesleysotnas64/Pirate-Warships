using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : DefaultShip
{
    protected Transform playerTransform;
    protected Vector3   playerDirection;
    protected List<Sensor> sensors;

    protected void UpdateDirection()
    {
        if (!sensors[0].Active && !sensors[1].Active)
        {
            playerTransform = GameObject.Find("Player").GetComponent<Transform>();
            playerDirection = (playerTransform.position-transform.position).normalized;

            transform.up = Vector3.Lerp(transform.up, playerDirection, 2*Time.deltaTime);
        }
        else
        {
            if (sensors[0].Active && !sensors[1].Active)
                Rudder(-curveRadius);
            else if (!sensors[0].Active && sensors[1].Active)
                Rudder(curveRadius);
        }
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (!stunned)
        {
            string tag = other.gameObject.tag;
            switch (tag)
            {
                case "PlayerProjectile":
                    Damage(1);
                    break;

                case "Player":
                    Damage(currentLife);
                    break;
            }
        }
    }
}
