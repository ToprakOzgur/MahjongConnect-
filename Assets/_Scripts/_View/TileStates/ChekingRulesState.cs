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
        // Debug.Log("Cheking  Rule state ENTER");
    }

    public void OnExit()
    {
        Debug.Log("Cheking  Rule state Exit");
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
