﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces)
    {
        return new RuleResult(false, RuleResultIdentifiers.GameWinRuleResultIdentifier);
    }
}
