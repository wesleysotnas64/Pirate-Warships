using System.Collections.Generic;
using UnityEngine;

public sealed class ChaserEnemy : DefaultEnemy
{

    void Start()
    {
        maxLife = 5;
        currentLife = maxLife;
        speed = 1;
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

        sound = GetComponent<AudioSource>();
        sound.volume = 0.1f;

        UpdateDirection();
    }

    void Update()
    {
        if (!stunned && playerTransform != null)
        {
            Navigate();
            UpdateDirection();
            AlertEffect();
        }
    }

    private void AlertEffect()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        angleEffect += Time.deltaTime*10;
        if (angleEffect >= 360) angleEffect = 0;
        float sinWave = (Mathf.Sin(angleEffect)+1)/2;

        sr.color = new Color(1, sinWave, sinWave, 1);

        if(1-sinWave > 0.9f) sound.Play(0);
    }
}
