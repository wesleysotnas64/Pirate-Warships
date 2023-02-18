using UnityEngine;

public class Cannon : MonoBehaviour
{
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
