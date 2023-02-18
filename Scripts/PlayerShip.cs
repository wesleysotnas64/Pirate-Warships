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
        }
        if (CurrentLife <= 0) Stunned = true;
    }
}
