using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed { get; set; }
    public float maxDistance { get; set; }
    public float currentDistance { get; set; }

    private void Start()
    {
        speed = 2;
        maxDistance = 2;
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
