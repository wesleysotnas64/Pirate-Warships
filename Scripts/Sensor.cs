using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool Active { get; set; }

    private void Start() {
        Active = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Active = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Active = false;
    }
}
