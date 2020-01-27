using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hint
{
    public List<Face> FindHint(Face[,] faceMatrix)
    {
        var pairs = DetectAllPairs(faceMatrix);

        foreach (var pair in pairs)
        {
            var pathFinder = new PathFinder();

            if (pathFinder.PathFind(faceMatrix, pair))
            {
                return pair;
            }

        }
        return null;
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
