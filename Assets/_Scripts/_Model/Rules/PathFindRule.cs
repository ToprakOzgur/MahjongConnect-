using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindRule : IRule
{
    // a modified A star pathfinding algorithm:

    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        //Checking if not pairs 
        //TODO: remove this ekstra check by calling mothod after pairsRule if validated
        if (selectedFaces[0].number != selectedFaces[1].number)
            return new RuleResult(false, RuleResultIdentifiers.PathFindRuleIdentifier);

        //Expends array 2*2 for extra rotate  from outside of bounds . 
        //(1 line to each left, right, top and bottom borders).
        var expandedFaceMatrix = new Face[faceMatrix.GetLength(0) + 2, faceMatrix.GetLength(1) + 2];

        for (int i = 1; i < expandedFaceMatrix.GetLength(1) - 1; i++)
        {
            for (int j = 1; j < expandedFaceMatrix.GetLength(0) - 1; j++)
            {
                expandedFaceMatrix[j, i] = faceMatrix[j - 1, i - 1];

                //Getting slected Face Coordinates(index)
                if (expandedFaceMatrix[j, i] != null)
                {
                    if (expandedFaceMatrix[j, i].number == selectedFaces[0].number)
                    {
                        Debug.Log(j + " : " + i + " = " + expandedFaceMatrix[j, i].number);
                    }
                }
            }
        }

        return new RuleResult(true, RuleResultIdentifiers.PathFindRuleIdentifier);
    }
}
