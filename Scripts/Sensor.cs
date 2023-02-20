using UnityEngine;

public sealed class Sensor : MonoBehaviour
{
    private bool active;

    [SerializeField]
    private Sensor mirroredSensor;

    private void Start() {
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!mirroredSensor.Active)
            active = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!mirroredSensor.Active)
            active = false;
    }

    public bool Active
    {
        get { return this.active; }
    }
}
