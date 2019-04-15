using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TerritoryHighlightMode {
    None, PlayerHover, PlayerSelected
}

public class Territory : MonoBehaviour
{
    public TerritoryHighlightMode highlightMode;
    private SpriteRenderer spriteRenderer;
    private Color spriteRendererHighlightColor;
    private Color spriteRendererSelectedColor;
    private Color originalSpriteRendererColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRendererHighlightColor = Color.green;
        spriteRendererSelectedColor = Color.blue;
        originalSpriteRendererColor = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {
        switch (highlightMode)
        {
            case TerritoryHighlightMode.None:
                spriteRenderer.color = originalSpriteRendererColor;
                break;
            case TerritoryHighlightMode.PlayerHover:
                spriteRenderer.color = spriteRendererHighlightColor;
                break;
            case TerritoryHighlightMode.PlayerSelected:
                spriteRenderer.color = spriteRendererSelectedColor;
                break;
        }
    }
}
