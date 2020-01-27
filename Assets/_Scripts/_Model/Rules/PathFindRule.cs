
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindRule : IRule
{

    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        var pathFinder = new PathFinder();
        var result = pathFinder.PathFind(faceMatrix, selectedFaces);
        return new RuleResult(result, RuleResultIdentifiers.PathFindRuleIdentifier);
    }



}


