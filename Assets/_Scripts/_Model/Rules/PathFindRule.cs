
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFindRule : IRule
{
    List<Coords> selectedFaceCoords = new List<Coords>();
    public RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces)
    {
        //Checking if not pairs 
        //TODO: remove this ekstra check by calling mothod after pairsRule  validated
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

                        selectedFaceCoords.Add(new Coords(j, i));
                    }
                }
            }
        }


        var pathFindingResult = IsToFaceConnectedWithTwoRotation(expandedFaceMatrix, selectedFaceCoords);

        return new RuleResult(pathFindingResult, RuleResultIdentifiers.PathFindRuleIdentifier);
    }

    //Path Finding Algorithm (similar to A star algorithm but costs  are rotations not distances)
    private bool IsToFaceConnectedWithTwoRotation(Face[,] faces, List<Coords> selectedFaceCoords)
    {
        var nodes = new Node[faces.GetLength(0), faces.GetLength(1)];

        for (int i = 0; i < nodes.GetLength(1); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                nodes[j, i] = new Node(faces[j, i] == null, new Coords(j, i));
            }
        }

        Node startNode = nodes[selectedFaceCoords[0].rowNumber, selectedFaceCoords[0].columnNumber];
        Node endNode = nodes[selectedFaceCoords[1].rowNumber, selectedFaceCoords[1].columnNumber];

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            //Up
            for (int i = openSet[0].coords.columnNumber; i < nodes.GetLength(1); i++)
            {
                if (nodes[openSet[0].coords.rowNumber, i].isFull)
                    break;
                nodes[openSet[0].coords.rowNumber, i].cost++;
            }

            //Down
            for (int i = openSet[0].coords.columnNumber; i > 0; i--)
            {
                if (nodes[openSet[0].coords.rowNumber, i].isFull)
                    break;
                nodes[openSet[0].coords.rowNumber, i].cost++;
            }


            //Up
            for (int i = 0; i < nodes.GetLength(1); i++)
            {
                Debug.Log(nodes[openSet[0].coords.rowNumber, i].cost);

            }

            openSet.Remove(startNode);

        }

        return false;
    }

}


