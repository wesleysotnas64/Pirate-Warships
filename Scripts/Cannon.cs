using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject  ProjectilPrefab { get; set; }
    public AudioSource ShotSound { get; set; }

    private void Awake()
    {
        ProjectilPrefab = Resources.Load<GameObject>("Projectile");
        ShotSound = GetComponent<AudioSource>();
        ShotSound.volume = 0.025f;
    }

    public void Shoot()
    {
        Instantiate(ProjectilPrefab, transform.position, transform.rotation);
        ShotSound.Play(0);
    }
}
