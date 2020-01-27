using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    private readonly int targetRotateCount = 2;
    List<Coords> selectedFaceCoords = new List<Coords>();

    public bool PathFind(Face[,] faceMatrix, List<Face> selectedFaces)
    {

        if (selectedFaces[0].number != selectedFaces[1].number)
            return false;

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
                        selectedFaceCoords.Add(new Coords(j, i));
                    }
                }
            }
        }

        var pathFindingResult = IsToFaceConnectedWithTwoRotation(expandedFaceMatrix, selectedFaceCoords);
        selectedFaceCoords.Clear();
        return pathFindingResult;
    }
    //Path Finding Algorithm (similar to A star algorithm but costs  are rotations not distances)
    private bool IsToFaceConnectedWithTwoRotation(Face[,] faces, List<Coords> selectedFaceCoords)
    {

        var nodes = new Node[faces.GetLength(0), faces.GetLength(1)];

        for (int i = 0; i < nodes.GetLength(1); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                nodes[j, i] = new Node(faces[j, i] != null, new Coords(j, i));

            }
        }

        Node startNode = nodes[selectedFaceCoords[0].rowNumber, selectedFaceCoords[0].columnNumber];
        Node endNode = nodes[selectedFaceCoords[1].rowNumber, selectedFaceCoords[1].columnNumber];

        nodes[endNode.coords.rowNumber, endNode.coords.columnNumber].isFull = false;

        List<Node> unCheckedSet = new List<Node>();
        HashSet<Node> checkedSet = new HashSet<Node>();

        unCheckedSet.Add(startNode);

        while (unCheckedSet.Count > 0)
        {
            Node currentNode = unCheckedSet[0];

            //Up
            for (int i = currentNode.coords.columnNumber; i < nodes.GetLength(1); i++)
            {

                if (i == currentNode.coords.columnNumber)
                    continue;

                if (nodes[currentNode.coords.rowNumber, i].isFull)
                    break;

                if (CheckNodeIFUncheckedListOrIsTarget(nodes[currentNode.coords.rowNumber, i], unCheckedSet, checkedSet, currentNode, PathDirection.Vertical, endNode))
                {
                    return true;
                }
            }

            //Down
            for (int i = currentNode.coords.columnNumber; i >= 0; i--)
            {
                if (i == currentNode.coords.columnNumber)
                    continue;

                if (nodes[currentNode.coords.rowNumber, i].isFull)
                    break;

                if (CheckNodeIFUncheckedListOrIsTarget(nodes[currentNode.coords.rowNumber, i], unCheckedSet, checkedSet, currentNode, PathDirection.Vertical, endNode))
                {
                    return true;
                }
            }

            //Right
            for (int i = currentNode.coords.rowNumber; i < nodes.GetLength(0); i++)
            {
                if (i == currentNode.coords.rowNumber)
                    continue;

                if (nodes[i, currentNode.coords.columnNumber].isFull)
                    break;


                if (CheckNodeIFUncheckedListOrIsTarget(nodes[i, currentNode.coords.columnNumber], unCheckedSet, checkedSet, currentNode, PathDirection.Horizontal, endNode))
                {
                    return true;
                }
            }

            //Left
            for (int i = currentNode.coords.rowNumber; i >= 0; i--)
            {
                if (i == currentNode.coords.rowNumber)
                    continue;

                if (nodes[i, currentNode.coords.columnNumber].isFull)
                    break;


                if (CheckNodeIFUncheckedListOrIsTarget(nodes[i, currentNode.coords.columnNumber], unCheckedSet, checkedSet, currentNode, PathDirection.Horizontal, endNode))
                {
                    return true;
                }
            }


            unCheckedSet.Remove(currentNode);
            checkedSet.Add(currentNode);

        }
        return false;
    }


    private bool CheckNodeIFUncheckedListOrIsTarget(Node node, List<Node> unCheckedSet, HashSet<Node> checkedSet, Node currentNode, PathDirection direction, Node endNode)
    {

        if (!checkedSet.Contains(node) && !unCheckedSet.Contains(node))
        {

            if (direction == currentNode.direction || currentNode.direction == PathDirection.NotCalculated)
            {
                node.cost = currentNode.cost;
            }
            else
            {
                node.cost = currentNode.cost + 1;
            }

            if (node.coords.rowNumber == endNode.coords.rowNumber && node.coords.columnNumber == endNode.coords.columnNumber)
            {
                Debug.LogError("found target.Cost= " + node.cost);
                return node.cost <= targetRotateCount;
            }
            else
            {
                node.direction = direction;
                unCheckedSet.Add(node);
            }

            // Debug.Log(node.coords.rowNumber + " : " + node.coords.columnNumber);

        }
        return false;
    }

}
