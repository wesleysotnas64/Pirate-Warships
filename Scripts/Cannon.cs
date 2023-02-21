using UnityEngine;

public sealed class Cannon : MonoBehaviour
{
    private GameObject  projectilPrefab;
    private GameObject  fireShot;
    private AudioSource shotSound;

    [SerializeField]
    private float reloadTime;
    private float currentTime;

    [SerializeField]
    private float projectilePower;
    

    private void Start()
    {
        string parent = transform.parent.tag;
        if (parent == "Player")
            projectilPrefab = Resources.Load<GameObject>("PlayerProjectile");
        else
            projectilPrefab = Resources.Load<GameObject>("EnemyProjectile");

        fireShot = Resources.Load<GameObject>("Fire");

        shotSound = GetComponent<AudioSource>();
        shotSound.volume = 0.025f;

        currentTime = 0;
    }

    private void Update() {
        if (currentTime < reloadTime)
            currentTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if (currentTime >= reloadTime)
        {
            currentTime = 0;
            GameObject projectil = Instantiate(projectilPrefab, transform.position, transform.rotation);
            projectil.GetComponent<Projectile>().SetProjectil(projectilePower);
            shotSound.Play(0);

            GameObject fire = Instantiate(fireShot, transform.position, transform.rotation);
            fire.transform.parent = gameObject.transform;
            fire.transform.Translate(0,0.2f,0);
            
        }
    }
}
