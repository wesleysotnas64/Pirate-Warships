using System.Collections.Generic;
using UnityEngine;
using Enum;

public class EnemySpawner : MonoBehaviour
{
    private bool active;
    [SerializeField]
    private List<Vector3> spawnPosition;
    private GameObject EnemySpawn;
    private float spawnTime;
    private float currentTime;
    
    void Start()
    {
        spawnPosition = new List<Vector3>();
        for(int i = 0; i < 4; i++)
        {
            Vector3 pos = gameObject.transform.GetChild(i).position;
            spawnPosition.Add(pos);
        }

        spawnTime = 10;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            Spawn();
    }

    private void Spawn()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            currentTime = 0;

            int pList = Random.Range(0, 4);
            int eSpaw = Random.Range(1, 3);

            switch (eSpaw)
            {
                case (int)Enemy.chaserEnemy:
                    EnemySpawn = Resources.Load<GameObject>("ChaserEnemy");
                    break;
                
                case (int)Enemy.shooterEnemy:
                    EnemySpawn = Resources.Load<GameObject>("ShooterEnemy");
                    break;
            }

            Instantiate(EnemySpawn, spawnPosition[pList], transform.rotation);
        }
    }

    public bool Active
    {
        get { return this.active;  }
        set { this.active = value; }
    }
}
