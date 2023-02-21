using UnityEngine;

public sealed class FinalizationEffect : MonoBehaviour
{
    [SerializeField]
    private float destructTime;

    private void Start() {
        string tag = gameObject.tag;
        switch (tag)
        {
            case "Explosion":
                DestructIn(destructTime);
                break;
            
            case "Fire":
                DestructIn(destructTime);
                break;
            
        }
    }

    private void DestructIn(float time)
    {
        Destroy(this.gameObject, time);
    }
}
