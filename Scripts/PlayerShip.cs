using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : DefaultShip
{
    private float HeavyReloadTime { get; set; }
    private float CurrentHeavyReloadTime { get; set; }

    private void Start()
    {
        MaxLife = 10;
        CurrentLife = MaxLife;
        Speed = 1;
        CurveRadius = 45;
        SimpleReloadTime = 1;
        HeavyReloadTime  = 5;
        CurrentSimpleReloadTime = 0;
        CurrentHeavyReloadTime  = 0;
        Stunned = false;

        UpdateStatus();

        LifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        LifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        Cannons = new List<GameObject>();
        for(int i = 0; i < 7; i++)
        {
            GameObject cannnon = gameObject.transform.GetChild(i).gameObject;
            Cannons.Add(cannnon);
        }
    }

    private void Update()
    {
        if (!Stunned)
        {
            if (Input.GetKey("w")) Navigate(Speed);
            if (Input.GetKey("a")) Rudder( CurveRadius);
            if (Input.GetKey("d")) Rudder(-CurveRadius);

            if (Input.GetKeyDown("p"))
            {
                CurrentLife--;
                UpdateStatus();
                LifeBar.GetComponent<LifeBar>().UpdateScale((float)CurrentLife / MaxLife);
            }

            if (Input.GetKeyDown("i")) Cannons[0].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("j"))
                for (int i = 1; i < 4; i++)  Cannons[i].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("l"))
                for (int i = 4; i < 7; i++)  Cannons[i].GetComponent<Cannon>().Shoot();
        }
        if (CurrentLife <= 0) Stunned = true;
    }
}
