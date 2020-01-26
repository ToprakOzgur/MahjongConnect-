using System.Collections;
using System.Collections.Generic;
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
        game.FaceSelected(selectedTile.Face);
        selectedTileViews.Add(selectedTile);

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

    }
    public void TurnSuccessAction()
    {

    }
    public void ChangeAllTileToChekingRulesState()
    {
        foreach (var tileView in tileViews)
        {
            tileView.ChangeState(tileView.chekingRulesState);
        }

    }
}
