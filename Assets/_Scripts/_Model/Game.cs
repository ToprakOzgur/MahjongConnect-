using System;
using System.Collections;
using System.Collections.Generic;
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
