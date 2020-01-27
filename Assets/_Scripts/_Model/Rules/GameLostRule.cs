using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLostRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        var pairs = DetectAllPairs(faceMatrix);
        var result = true;

        foreach (var pair in pairs)
        {
            var pathFinder = new PathFinder();

            if (pathFinder.PathFind(faceMatrix, pair))
                result = false;
        }
        Debug.LogError("GAME LOST= " + result);
        return new RuleResult(result, RuleResultIdentifiers.GameLostRuleIdentifier);
    }


    private List<List<Face>> DetectAllPairs(Face[,] faceMatrix)
    {
        var pairsDictionary = new Dictionary<int, List<Face>>();

        //find all pairs
        foreach (var face in faceMatrix)
        {
            if (face == null)
                continue;

            if (!pairsDictionary.ContainsKey(face.number))
                pairsDictionary.Add(face.number, new List<Face> { face });
            else
            {
                pairsDictionary[face.number].Add(face);
            }
        }
        var pairs = pairsDictionary.Values.ToList();
        return pairs;
    }
}
