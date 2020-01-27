﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogicController : MonoBehaviour
{
    private Game game;
    [HideInInspector] public List<Tile> tileViews = new List<Tile>();
    [HideInInspector] public List<Tile> selectedTileViews = new List<Tile>();
    public void CreateNewGame(Face[,] faceMatrix)
    {
        game = new Game(this, faceMatrix);
    }

    public void TileIsSelected(Tile selectedTile)
    {
        selectedTileViews.Add(selectedTile);
        game.FaceSelected(selectedTile.Face);
    }

    public void TileDeselected(Tile selectedTile)
    {
        game.FaceDeselected(selectedTile.Face);
        selectedTileViews.Remove(selectedTile);

    }

    public void GameWon()
    {
        Debug.Log("GameWon");
    }

    public void TurnFailedAction()
    {
        ChangeAllTileIdleState();
        selectedTileViews.Clear();
    }
    public void TurnSuccessAction()
    {
        foreach (var tile in selectedTileViews)
        {
            if (tile != null)
                Destroy(tile.gameObject);
            tileViews.Remove(tile);
        }

        ChangeAllTileIdleState();
    }
    public void ChangeAllTileToChekingRulesState()
    {
        foreach (var tileView in tileViews)
        {
            tileView.ChangeState(tileView.chekingRulesState);
        }
    }
    public void ChangeAllTileIdleState()
    {
        foreach (var tileView in tileViews)
        {
            tileView.ChangeState(tileView.idleState);
        }
    }

    public void ShowHint()
    {
        var hintPairs = game.ShowHint();
        var hintTiles = new List<Tile>();

        if (hintPairs != null)
        {
            foreach (var tile in tileViews)
            {
                if (tile != null)
                {
                    if (tile.face.number == hintPairs[0].number)
                    {
                        tile.tileColorChanger.ChangeColorToHintColor();
                    }
                }
            }
        }
    }
}
