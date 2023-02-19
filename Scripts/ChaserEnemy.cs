using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : DefaultEnemy
{
    private float Angle { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        MaxLife = 6;
        CurrentLife = MaxLife;
        Speed = 1;
        CurveRadius = 45;
        
        

        LifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        LifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        Sensors = new List<Sensor>();
        for (int i = 0; i < 2; i++)
        {
            Sensor sensor = gameObject.transform.GetChild(i).gameObject.GetComponent<Sensor>();
            Sensors.Add(sensor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Stunned)
            Navigate();
        UpdateDirection();
        AlertEffect();
    }

    private void AlertEffect()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Angle += Time.deltaTime*10;
        if (Angle >= 360) Angle = 0;
        //Angle = Angle * (Mathf.PI * 180);
        float sinWave = (Mathf.Sin(Angle)+1)/2;

        sr.color = new Color(1, sinWave, sinWave, 1);
    }
}
