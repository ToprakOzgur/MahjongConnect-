using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public Face face;
    [HideInInspector] public Coords coords;
    [SerializeField] private SpriteRenderer faceSpriteRenderer;
    private GameLogicController controller;
    private bool isSelected;
    public Face Face
    {
        get => face;
        set
        {
            face = value;
            faceSpriteRenderer.sprite = face.sprite;
        }
    }

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;

            if (isSelected)
            {
                controller.TileIsSelected(this);
            }
            else
            {
                controller.TileDeselected(this);
            }
        }
    }

    public void AddFaceToTile(Face face)
    {
        this.Face = face;
    }

    public void AddController(GameLogicController controller)
    {
        this.controller = controller;
    }
    private void OnMouseDown()
    {
        IsSelected = !IsSelected;
    }
}

public struct Coords
{
    public int posX;
    public int posY;
}
