using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PairsSelectedRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {

        if (selectedFaces[0].number == selectedFaces[1].number)
        {
            Debug.Log("PAIRS");
            return new RuleResult(true, RuleResultIdentifiers.PairsSelectedRuleIdentifier);
        }

        return new RuleResult(false, RuleResultIdentifiers.PairsSelectedRuleIdentifier);
    }
}
