using UnityEngine;
using Enum;

public class DefaultShip : MonoBehaviour
{
    protected int   MaxLife { get; set; }
    protected int   CurrentLife { get; set; }
    protected float Speed { get; set; }
    protected float CurveRadius { get; set; }
    protected float SimpleReloadTime { get; set; }
    protected float CurrentSimpleReloadTime { get; set; }
    protected bool  Stunned { get; set; }
    protected State State { get; set; }
    protected GameObject LifeBar { get; set; }

    protected void Navigate(float _speed)
    {
        transform.Translate(0, -_speed * Time.deltaTime, 0);
    }

    protected void Rudder(float _curveRadius)
    {
        transform.Rotate(0, 0, _curveRadius * Time.deltaTime);
    }

    protected void UpdateStatus()
    {
        float st = (float) CurrentLife / MaxLife;
        if (st > 0.6f) State = State.FullLife;
        else if (st > 0.3f) State = State.HalfLife;
        else if (st > 0) State = State.LowLife;
        else State = State.EmptyLife;

        GetComponent<Animator>().SetInteger("State", (int) State);
    }
}
