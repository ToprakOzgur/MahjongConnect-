using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ITileState
{
    private readonly Tile tile;

    public IdleState(Tile tile)
    {
        this.tile = tile;
    }
    public void OnEnter()
    {
        tile.tileColorChanger.ChangeColorToIdle();
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
        tile.controller.TileIsSelected(tile);
        tile.ChangeState(tile.selectedState);
        Debug.Log("selected");
    }
}
