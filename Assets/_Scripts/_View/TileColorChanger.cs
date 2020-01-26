using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileColorChanger : MonoBehaviour
{
    public Color idleColor;
    public Color highlightedColor;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeColorToIdle()
    {
        spriteRenderer.color = idleColor;
    }
    public void ChangeColorToHighlighted()
    {
        spriteRenderer.color = highlightedColor;
    }
}
