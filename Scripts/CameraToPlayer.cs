using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if(Vector3.Distance(transform.position, playerTransform.position) > 0.1f)
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime);
    }
}
