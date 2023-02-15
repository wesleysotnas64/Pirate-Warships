using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts;

public class PlayerShip : DefaultShip
{
    private float HeavyReloadTime { get; set; }
    private void Start()
    {
        this.Life = 10;
        this.Speed = 1;
        this.CurveRadius = 45;
        this.SimpleReloadTime = 1;
        this.HeavyReloadTime = 5;
        this.Stunned = false;
    }

    private void Update()
    {
        if (!this.Stunned)
        {
            if (Input.GetKey("w")) Navigate(this.Speed);
            if (Input.GetKey("a")) Rudder( this.CurveRadius);
            if (Input.GetKey("d")) Rudder(-this.CurveRadius);
        }
    }
}
