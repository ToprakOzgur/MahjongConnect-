using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PairsSelectedRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces)
    {
        var faces = selectedFaces.Keys.ToList();

        if (faces[0].number == faces[1].number)
        {
            Debug.Log("PAIRS");
            return new RuleResult(true, RuleResultIdentifiers.PairsSelectedRuleIdentifier);
        }

        return new RuleResult(false, RuleResultIdentifiers.PairsSelectedRuleIdentifier);
    }
}
