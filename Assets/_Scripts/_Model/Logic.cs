using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Logic
{
    List<IRule> rules = new List<IRule>();
    public Logic()
    {
        rules.Add(new PathBetweenSelectedPairsIsEmptyRule());
        rules.Add(new PairsSelectedRule());
        rules.Add(new MaxTwoReturnToPairRule());
        rules.Add(new GameWinRule());
        rules.Add(new GameLostRule());
    }
    public List<RuleResult> CheckRules(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces)
    {
        var ruleResults = new List<RuleResult>();

        foreach (var rule in rules)
        {
            ruleResults.Add(rule.Validate(faceMatrix, selectedFaces));
        }

        return ruleResults;
    }
}
