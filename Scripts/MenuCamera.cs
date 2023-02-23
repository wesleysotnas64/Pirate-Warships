using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private Vector3 target;

    void Awake()
    {
        SetMenuAsTarget();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.Lerp(transform.position, target, 5*Time.deltaTime);
    }

    public void SetMenuAsTarget()
    {
        target = new Vector3(0,0,-10);
    }

    public void SetSettingsAsTarget()
    {
        target = new Vector3(0,-36,-10);
    }
}
