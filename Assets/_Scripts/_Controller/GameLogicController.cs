using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicController : MonoBehaviour
{

    private Game game;
    public void CreateNewGame(Face[,] faceMatrix)
    {
        game = new Game(this, faceMatrix);
    }

    public void TileIsSelected(Tile selectedTile)
    {
        game.FaceSelected(selectedTile.face, selectedTile.coords);
    }

    public void TileDeselected(Tile selectedTile)
    {
        game.FaceDeselected(selectedTile.face);
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
}
