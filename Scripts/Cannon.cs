using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject ProjectilPrefab;

    private void Awake()
    {
        ProjectilPrefab = Resources.Load<GameObject>("Projectile");
    }

    public void Shoot()
    {
        Instantiate(ProjectilPrefab, transform.position, transform.rotation);
    }
}
