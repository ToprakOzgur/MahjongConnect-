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
        Debug.Log("IdleState ENTER");
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
        tile.ChangeState(tile.selectedState);
        tile.controller.TileIsSelected(tile);
        Debug.Log("selected");
    }
}
