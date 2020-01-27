using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game
{
    private GameLogicController gameContoller;
    private Face[,] faceMatrix;
    private Logic gameLogic;
    private List<Face> selectedFacesList = new List<Face>();

    public Game(GameLogicController gameContoller, Face[,] faceMatrix)
    {
        this.faceMatrix = faceMatrix;
        this.gameContoller = gameContoller;
        gameLogic = new Logic();
    }

    public void FaceSelected(Face selectedFace)
    {

        selectedFacesList.Add(selectedFace);

        if (selectedFacesList.Count == 2)
        {
            //Makes all tileviews checking rules state

            gameContoller.ChangeAllTileToChekingRulesState();

            CheckRules();

        }
    }
    public void CheckRules()
    {
        Debug.Log("Checking Rules");
        var results = gameLogic.CheckRules(faceMatrix, selectedFacesList);
        RuleResultActions(results);
    }
    public void FaceDeselected(Face selectedFace)
    {
        selectedFacesList.Remove(selectedFace);
    }

    public void RuleResultActions(List<RuleResult> ruleResults)
    {
        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.GameLostRuleIdentifier && x.result))
        {
            GameLost();
            return;
        }

        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.PairsSelectedRuleIdentifier && !x.result)) //there is SmallOverBigRule and result is false
        {
            TurnFail();
            return;
        }

        //there is SmallOverBigRule and result is true
        if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.PathFindRuleIdentifier && x.result))
        {
            TurnSuccess();
        }
        else
        {
            TurnFail();
        }


    }


    private void TurnSuccess()
    {
        Debug.LogError("turn success");
        RemoveSelecPairsFromMatrix();

        gameContoller.TurnSuccessAction();
        selectedFacesList.Clear();

        if (CheckLevelWin())
            LevelWinActions();

    }

    private void LevelWinActions()
    {
        Debug.LogWarning("LevelWinnnn");
    }

    private void TurnFail()
    {
        Debug.LogError("turn fail");

        gameContoller.TurnFailedAction();
        selectedFacesList.Clear();
    }

    private bool CheckLevelWin()
    {
        var result = true;
        foreach (var face in faceMatrix)
        {
            if (face != null)
                result = false;
        }
        return result;
    }

    private void GameLost()
    {
        Debug.LogError("GAME LOST ");
    }
    private void RemoveSelecPairsFromMatrix()
    {
        var selectedFaceCoords = new List<Coords>();

        for (int i = 0; i < faceMatrix.GetLength(1); i++)
        {
            for (int j = 0; j < faceMatrix.GetLength(0); j++)
            {
                if (faceMatrix[j, i] != null && faceMatrix[j, i].number == selectedFacesList[0].number)
                {
                    selectedFaceCoords.Add(new Coords(j, i));
                }
            }
        }

        foreach (var coords in selectedFaceCoords)
        {
            faceMatrix[coords.rowNumber, coords.columnNumber] = null;
        }

        foreach (var face in faceMatrix)
        {
            if (face != null)
                Debug.LogWarning("kalan");
        }
    }


    public List<Face> ShowHint()
    {
        var hint = new Hint();
        var pairs = hint.FindHint(faceMatrix);

        return pairs;
    }
}
