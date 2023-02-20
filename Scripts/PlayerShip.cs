using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerShip : DefaultShip
{
    private void Start()
    {
        maxLife = 10;
        currentLife = maxLife;
        speed = 2;
        curveRadius = 45;
        stunned = false;

        UpdateStatus();

        lifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        lifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        cannons = new List<GameObject>();
        for(int i = 0; i < 7; i++)
        {
            GameObject cannon = gameObject.transform.GetChild(i).gameObject;
            cannons.Add(cannon);
        }
    }

    private void Update()
    {
        if (!stunned)
        {
            if (Input.GetKey("w")) Navigate();
            if (Input.GetKey("a")) Rudder( curveRadius);
            if (Input.GetKey("d")) Rudder(-curveRadius);

            if (Input.GetKeyDown("p"))
            {
                currentLife--;
                UpdateStatus();
                lifeBar.GetComponent<LifeBar>().UpdateScale((float)currentLife / maxLife);
            }

            if (Input.GetKeyDown("i")) cannons[0].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("j"))
                for (int i = 1; i < 4; i++)  cannons[i].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("l"))
                for (int i = 4; i < 7; i++)  cannons[i].GetComponent<Cannon>().Shoot();
        }
        if (currentLife <= 0) stunned = true;
    }
}
