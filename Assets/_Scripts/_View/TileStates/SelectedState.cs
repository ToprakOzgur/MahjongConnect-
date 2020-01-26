using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : ITileState
{
    private readonly Tile tile;

    public SelectedState(Tile tile)
    {
        this.tile = tile;
    }
    public void OnEnter()
    {
        tile.tileColorChanger.ChangeColorToHighlighted();
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void OnMouseDown()
    {
        tile.controller.TileDeselected(tile);
        tile.ChangeState(tile.idleState);
        Debug.Log("Deselect");
    }
}
