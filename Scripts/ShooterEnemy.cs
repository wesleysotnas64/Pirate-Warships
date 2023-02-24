using System.Collections.Generic;
using UnityEngine;

public sealed class ShooterEnemy : DefaultEnemy
{
    [SerializeField]
    private float shootingRadius;
    private void Start() {
        maxLife = 4;
        currentLife = maxLife;
        speed = 0.75f;
        curveRadius = 45;
        stunned = false;

        lifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        lifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        sensors = new List<Sensor>();
        for (int i = 0; i < 2; i++)
        {
            Sensor sensor = gameObject.transform.GetChild(i).gameObject.GetComponent<Sensor>();
            sensors.Add(sensor);
        }

        cannons = new List<GameObject>();
        GameObject cannon = gameObject.transform.GetChild(2).gameObject;
        cannons.Add(cannon);
        
        UpdateDirection();
    }

    void Update()
    {
        if(!stunned && playerTransform != null)
        {
            if (!OnTarget())
                Navigate();
            else
                cannons[0].GetComponent<Cannon>().Shoot();
            UpdateDirection();
        }
    }

    private bool OnTarget()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        return distance < shootingRadius ? true : false;
    }

}
