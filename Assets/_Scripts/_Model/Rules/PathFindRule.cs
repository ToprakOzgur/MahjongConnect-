using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindRule : IRule
{
    // a modified A star pathfinding algorithm:

    public RuleResult Validate(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces)
    {
        for (int i = 0; i < faceMatrix.GetLength(1); i++)
        {
            for (int j = 0; j < faceMatrix.GetLength(0); j++)
            {
                if (faceMatrix[j, i] != null)
                {
                    Debug.Log(j + " : " + i + " = " + faceMatrix[j, i].number);
                }
                else
                {
                    Debug.Log("null");
                }
            }
        }

        return new RuleResult(false, RuleResultIdentifiers.MaxTwoReturnToPairsRuleIdentifier);
    }
}
