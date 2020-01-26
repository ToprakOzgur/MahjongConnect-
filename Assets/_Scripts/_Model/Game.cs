using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private GameLogicController gameContoller;
    private Face[,] faceMatrix;
    private Logic gameLogic;
    private Dictionary<Face, Coords> selectedFaces = new Dictionary<Face, Coords>();

    public Game(GameLogicController gameContoller, Face[,] faceMatrix)
    {
        this.faceMatrix = faceMatrix;
        gameLogic = new Logic();
    }

    public void FaceSelected(Face selectedFace, Coords coords)
    {
        selectedFaces.Add(selectedFace, coords);

        if (selectedFaces.Keys.Count == 2)
        {
            CheckRules();
            // selectedFaces.Clear();
        }
    }
    public void CheckRules()
    {
        Debug.Log("Checking Rules");
        var results = gameLogic.CheckRules(faceMatrix, selectedFaces);
        RuleResultActions(results);
    }
    public void FaceDeselected(Face selectedTile)
    {

    }

    public void RuleResultActions(List<RuleResult> ruleResults)
    {
        // if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.SmallOverBigRuleResultIdentifier && !x.result)) //there is SmallOverBigRule and result is false
        // {
        //     gameContoller.TurnFailed();
        //     return;
        // }

        // if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.SmallOverBigRuleResultIdentifier && x.result))  //there is SmallOverBigRule and result is true
        //     gameContoller.TurnSuccess();


        // if (ruleResults.Any(x => x.identifier == RuleResultIdentifiers.GameWinRuleResultIdentifier && x.result)) //there is GameWinnRule and result is true
        // {
        //     gameContoller.GameWon();
        //     return;
        // }
    }
}
