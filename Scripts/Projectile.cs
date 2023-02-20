using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    private float speed;
    private float maxDistance;
    private float currentDistance;

    private void Start()
    {
        speed = 3;
        maxDistance = 4;
        currentDistance = 0;
    }

    private void FixedUpdate()
    {
        InTrajectory();
    }

    private void InTrajectory()
    {
        float vel = speed * Time.deltaTime;
        currentDistance += vel;
        transform.Translate(0, vel, 0);

        VerifyLimit();
    }

    private void VerifyLimit()
    {
        if(currentDistance >= maxDistance)
            Destroy(this.gameObject);
    }
}
