using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileColorChanger : MonoBehaviour
{
    private readonly WaitForSeconds hintBlankDelay = new WaitForSeconds(0.2f);
    public Color idleColor;
    public Color highlightedColor;
    public Color hintColor;
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

    public void ChangeColorToHintColor()
    {
        StartCoroutine(HintColorAnim());
    }

    IEnumerator HintColorAnim()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return hintBlankDelay;
            spriteRenderer.color = hintColor;
            yield return hintBlankDelay;
            ChangeColorToIdle();
        }

    }
}
