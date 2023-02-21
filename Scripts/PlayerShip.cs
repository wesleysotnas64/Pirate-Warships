using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerShip : DefaultShip
{
    private bool stranded;
    private Vector3 lastPosition;
    private float saveTime;
    private float currentSaveTime;
    private float stunnedTime;
    private float currentStunnedTime;
    private void Start()
    {
        maxLife = 10;
        currentLife = maxLife;
        speed = 2;
        curveRadius = 60;
        stunned = false;
        stranded = false;
        lastPosition = transform.position;
        currentSaveTime = 0;
        saveTime = 2;
        currentStunnedTime = 0;
        stunnedTime = 2;
        
        UpdateStatus();

        lifeBar = Instantiate(Resources.Load<GameObject>("LifeBar"));
        lifeBar.GetComponent<LifeBar>().ShipTransform = GetComponent<Transform>();

        cannons = new List<GameObject>();
        for(int i = 0; i < 7; i++)
        {
            GameObject cannon = gameObject.transform.GetChild(i).gameObject;
            cannons.Add(cannon);
        }

        sound = GetComponent<AudioSource>();
        sound.volume = 0.04f;
        sound.pitch = 2;
    }

    private void Update()
    {
        if (!stunned && !stranded)
        {
            SaveLastPosition();

            if (Input.GetKey("w")) Navigate();
            if (Input.GetKey("a")) Rudder( curveRadius);
            if (Input.GetKey("d")) Rudder(-curveRadius);

            if (Input.GetKeyDown("i")) cannons[0].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("j"))
                for (int i = 1; i < 4; i++)  cannons[i].GetComponent<Cannon>().Shoot();
            if (Input.GetKeyDown("l"))
                for (int i = 4; i < 7; i++)  cannons[i].GetComponent<Cannon>().Shoot();
        }
        
        if (stranded)
        {
            StrandedEffect();
            ReturnToLastPosition();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (!stunned)
        // {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "EnemyProjectile":
                Damage(1);
                break;
            
            case "Enemy":
                Damage(3);
                break;

            case "Island":
                stranded = true;
                break;

        }
        // }
    }

    private void StrandedEffect()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        angleEffect += Time.deltaTime*7;
        if (angleEffect >= 360) angleEffect = 0;
        float sinWave = (Mathf.Sin(angleEffect)+1)/2;

        Vector3 white  = new Vector3(1,1,1);
        Vector3 purple = new Vector3(0.5f, 0, 1); 
        Vector3 currentColor = Vector3.Lerp(white, purple, sinWave);

        sr.color = new Color
        (
            currentColor.x,
            currentColor.y,
            currentColor.z,
            1
        );

        if(1-sinWave > 0.9f) sound.Play(0);
    }

    private void SaveLastPosition()
    {
        currentSaveTime += Time.deltaTime;
        if(currentSaveTime >= saveTime)
        {
            currentSaveTime = 0;
            lastPosition = transform.position;
        }

    }

    private void ReturnToLastPosition()
    {
        currentStunnedTime += Time.deltaTime;
        if (currentStunnedTime >= stunnedTime)
        {
            stunned = false;
            stranded = false;
            transform.position = lastPosition; 
            currentSaveTime = 0;
            currentStunnedTime = 0;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = new Color(1, 1, 1, 1);
        }
    }
}
