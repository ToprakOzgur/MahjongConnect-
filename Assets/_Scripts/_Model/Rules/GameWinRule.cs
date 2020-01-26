using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        return new RuleResult(false, RuleResultIdentifiers.GameWinRuleResultIdentifier);
    }
}
