using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class DefaultShip : MonoBehaviour
    {
        protected int   Life { get; set; }
        protected float Speed { get; set; }
        protected float CurveRadius { get; set; }
        protected float SimpleReloadTime { get; set; }
        protected bool  Stunned { get; set; }

        protected void Navigate(float _speed)
        {
            transform.Translate(0, -_speed * Time.deltaTime, 0);
        }

        protected void Rudder(float _curveRadius)
        {
            transform.Rotate(0, 0, _curveRadius * Time.deltaTime);
        }
    }
}
