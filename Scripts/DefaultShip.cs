using System.Collections.Generic;
using UnityEngine;
using Enum;

public class DefaultShip : MonoBehaviour
{
    protected int   maxLife { get; set; }
    protected int   currentLife { get; set; }
    protected float speed { get; set; }
    protected float curveRadius { get; set; }
    protected float simpleReloadTime { get; set; }
    protected float currentSimpleReloadTime { get; set; }
    protected bool  stunned { get; set; }
    protected State state { get; set; }
    protected GameObject lifeBar { get; set; }
    protected List<GameObject> cannons {get; set;}

    protected void Navigate()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    protected void Rudder(float _curveRadius)
    {
        transform.Rotate(0, 0, _curveRadius * Time.deltaTime);
    }

    protected void UpdateStatus()
    {
        float st = (float) currentLife / maxLife;

        if (st > 0.6f) state = State.fullLife;
        else if (st > 0.3f) state = State.halfLife;
        else if (st > 0) state = State.lowLife;
        else state = State.emptyLife;

        GetComponent<Animator>().SetInteger("State", (int) state);
    }
}
