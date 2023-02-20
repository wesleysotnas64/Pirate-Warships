using UnityEngine;

public sealed class Cannon : MonoBehaviour
{
    private GameObject  projectilPrefab;
    private AudioSource shotSound;

    private void Awake()
    {
        projectilPrefab = Resources.Load<GameObject>("Projectile");

        shotSound = GetComponent<AudioSource>();
        shotSound.volume = 0.025f;
    }

    public void Shoot()
    {
        Instantiate(projectilPrefab, transform.position, transform.rotation);
        shotSound.Play(0);
    }
}
