using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLostRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        return new RuleResult(false, RuleResultIdentifiers.GameLostRuleIdentifier);
    }
}
