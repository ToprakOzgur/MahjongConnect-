﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Logic
{
    List<IRule> rules = new List<IRule>();
    public Logic()
    {
        rules.Add(new PairsSelectedRule());
        rules.Add(new PathFindRule());
        rules.Add(new GameLostRule());
    }
    public List<RuleResult> CheckRules(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        var ruleResults = new List<RuleResult>();

        foreach (var rule in rules)
        {
            ruleResults.Add(rule.Validate(faceMatrix, selectedFaces));
        }

        return ruleResults;
    }
}
