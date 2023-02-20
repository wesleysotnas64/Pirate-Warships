using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    private float speed;
    private float maxDistance;
    private float currentDistance;

    private void Awake()
    {
        speed = 0;
        maxDistance = 0;
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

    public void SetProjectil(float _projectilePower)
    {
        speed = _projectilePower;
        maxDistance = _projectilePower/2;
    }
}
