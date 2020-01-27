using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogicController : MonoBehaviour
{
    private Game game;

    [HideInInspector] public List<Tile> tileViews = new List<Tile>();
    [HideInInspector] public List<Tile> selectedTileViews = new List<Tile>();

    private void Start()
    {
        var highScore = PlayerPrefs.GetInt($"level{GameManager.Instance.CurrentLevelNumber}score");
        UpdateHighScore(highScore);
    }
    public void CreateNewGame(Face[,] faceMatrix)
    {
        var highScore = PlayerPrefs.GetInt($"level{GameManager.Instance.CurrentLevelNumber}score");

        game = new Game(this, faceMatrix, highScore);
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
        GameManager.Instance.SaveCurrentGameWon();
        FindObjectOfType<UIManager>().ShowWonPopup();

    }
    public void GameLost()
    {
        FindObjectOfType<UIManager>().ShowLostPopup();
    }

    public void TurnFailedAction(int score)
    {
        ChangeAllTileIdleState();
        selectedTileViews.Clear();

        UIManager.Instance.UpdateScore(score);
    }
    public void TurnSuccessAction(int score)
    {
        foreach (var tile in selectedTileViews)
        {
            if (tile != null)
                Destroy(tile.gameObject);
            tileViews.Remove(tile);
        }
        UIManager.Instance.UpdateScore(score);
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

    public void UpdateHighScore(int score)
    {
        PlayerPrefs.SetInt($"level{GameManager.Instance.CurrentLevelNumber}score", score);
        UIManager.Instance.UpdateHighScore(score);

    }
}
