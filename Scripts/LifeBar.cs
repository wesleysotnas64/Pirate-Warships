using UnityEngine;

public sealed class LifeBar : MonoBehaviour
{
    private Transform shipTransform;
    private Transform childLifeBar;
    private Vector3   fullLifeColor;
    private Vector3   halfLifeColor;
    private Vector3   emptyLifeColor;
    private Vector3   currentLifeColor;
    private float     yOffset;
    private SpriteRenderer childSprite;

    private void Awake()
    {
        fullLifeColor  = new Vector3(0, 1, 0);
        halfLifeColor  = new Vector3(1, 1, 0);
        emptyLifeColor = new Vector3(1, 0, 0);
        yOffset = 0.7f;
        childLifeBar = gameObject.transform.GetChild(0);
        childSprite  = childLifeBar.gameObject.GetComponent<SpriteRenderer>();
        UpdateColor(1);
    }

    private void Update()
    {
        if(childLifeBar != null)
        {
           transform.position = new Vector3
            (
                shipTransform.position.x,
                shipTransform.position.y + yOffset,
                shipTransform.position.z
            );
        }
    }

    public void UpdateScale(float scale)
    {
        childLifeBar.localScale = new Vector3(scale, 1, 1);
        UpdateColor(scale);
    }

    private void UpdateColor(float interpolation)
    {
        if (interpolation > 0.5f)
        {
            interpolation    = (interpolation-0.5f)/0.5f;
            currentLifeColor = Vector3.Lerp(halfLifeColor, fullLifeColor, interpolation);
        }
        else
        {
            interpolation    = interpolation / 0.5f;
            currentLifeColor = Vector3.Lerp(emptyLifeColor, halfLifeColor, interpolation);
        }

        childSprite.color = new Color
        (
            currentLifeColor.x,
            currentLifeColor.y,
            currentLifeColor.z,
            1
        );
    }

    public Transform ShipTransform
    {
        get { return this.shipTransform;  }
        set { this.shipTransform = value; }
    }
}
