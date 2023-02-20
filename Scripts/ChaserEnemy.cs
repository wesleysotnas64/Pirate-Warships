using System.Collections.Generic;
using UnityEngine;

public sealed class ChaserEnemy : DefaultEnemy
{
    private float angle;
    private AudioSource alertSound;

    void Start()
    {
        maxLife = 5;
        currentLife = maxLife;
        speed = 1;
        curveRadius = 45;

        lifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        lifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        sensors = new List<Sensor>();
        for (int i = 0; i < 2; i++)
        {
            Sensor sensor = gameObject.transform.GetChild(i).gameObject.GetComponent<Sensor>();
            sensors.Add(sensor);
        }

        alertSound = GetComponent<AudioSource>();
        alertSound.volume = 0.1f;
    }

    void Update()
    {
        Navigate();
        UpdateDirection();
        AlertEffect();
    }

    private void AlertEffect()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        angle += Time.deltaTime*10;
        if (angle >= 360) angle = 0;
        float sinWave = (Mathf.Sin(angle)+1)/2;

        sr.color = new Color(1, sinWave, sinWave, 1);

        if(1-sinWave > 0.9f) alertSound.Play(0);
    }
}
