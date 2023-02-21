using UnityEngine;

public class Sea : MonoBehaviour
{
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        float offset = Time.time * 1;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset/3, offset/2));
    }
}
