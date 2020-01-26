using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekingRulesState : ITileState
{
    private readonly Tile tile;
    public ChekingRulesState(Tile tile)
    {
        this.tile = tile;
    }
    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnMouseDown()
    {
        Debug.Log("checking rules, tile cannot be selected");
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
