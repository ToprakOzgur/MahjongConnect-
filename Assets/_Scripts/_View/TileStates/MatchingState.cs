using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingState : ITileState
{
    private readonly Tile tile;
    public MatchingState(Tile tile)
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

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
    public void OnMouseDown()
    {
        Debug.Log("Tile already matched,mathing animations in progress.");
    }
}
