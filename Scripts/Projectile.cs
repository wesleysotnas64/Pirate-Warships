using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed { get; set; }

    [SerializeField]
    public float maxDistance { get; set; }

    [SerializeField]
    public float currentDistance { get; set; }

    private void Start()
    {
        speed = 2;
        maxDistance = 1;
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
        transform.Translate(vel, 0, 0);

        VerifyLimit();
    }

    private void VerifyLimit()
    {
        if(currentDistance >= maxDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
