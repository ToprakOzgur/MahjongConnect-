
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
                nodes[j, i] = new Node(faces[j, i] != null, new Coords(j, i));
            }
        }

        Node startNode = nodes[selectedFaceCoords[0].rowNumber, selectedFaceCoords[0].columnNumber];
        Node endNode = nodes[selectedFaceCoords[1].rowNumber, selectedFaceCoords[1].columnNumber];



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
                {

                    if (currentNode.coords.rowNumber == endNode.coords.rowNumber && i == endNode.coords.columnNumber)
                    {
                        if (currentNode.direction == PathDirection.NotCalculated || currentNode.direction == PathDirection.Vertical)
                            Debug.LogError("found target.cost= " + currentNode.cost);
                        else
                        {
                            Debug.LogError("found target.cost= " + (currentNode.cost + 1));
                        }
                    }


                    break;
                }


                CheckNodeIFUncheckedList(nodes[currentNode.coords.rowNumber, i], unCheckedSet, checkedSet, currentNode, PathDirection.Horizontal);
            }

            //Down
            for (int i = currentNode.coords.columnNumber; i >= 0; i--)
            {
                if (i == currentNode.coords.columnNumber)
                    continue;

                if (nodes[currentNode.coords.rowNumber, i].isFull)
                {
                    if (currentNode.coords.rowNumber == endNode.coords.rowNumber && i == endNode.coords.columnNumber)
                    {
                        if (currentNode.direction == PathDirection.NotCalculated || currentNode.direction == PathDirection.Vertical)
                            Debug.LogError("found target.cost= " + currentNode.cost);
                        else
                        {
                            Debug.LogError("found target.cost= " + (currentNode.cost + 1));
                        }
                    }
                    break;
                }

                CheckNodeIFUncheckedList(nodes[currentNode.coords.rowNumber, i], unCheckedSet, checkedSet, currentNode, PathDirection.Vertical);
            }

            //Right
            for (int i = currentNode.coords.rowNumber; i < nodes.GetLength(0); i++)
            {
                if (i == currentNode.coords.rowNumber)
                    continue;

                if (nodes[i, currentNode.coords.columnNumber].isFull)
                {
                    if (currentNode.coords.columnNumber == endNode.coords.columnNumber && i == endNode.coords.rowNumber)
                    {
                        if (currentNode.direction == PathDirection.NotCalculated || currentNode.direction == PathDirection.Vertical)
                            Debug.LogError("found target.cost= " + currentNode.cost);
                        else
                        {
                            Debug.LogError("found target.cost= " + (currentNode.cost + 1));
                        }
                    }
                    break;
                }

                CheckNodeIFUncheckedList(nodes[i, currentNode.coords.columnNumber], unCheckedSet, checkedSet, currentNode, PathDirection.Horizontal);
            }

            //Left
            for (int i = currentNode.coords.rowNumber; i >= 0; i--)
            {
                if (i == currentNode.coords.rowNumber)
                    continue;

                if (nodes[i, currentNode.coords.columnNumber].isFull)
                {
                    if (currentNode.coords.columnNumber == endNode.coords.columnNumber && i == endNode.coords.rowNumber)
                    {
                        if (currentNode.direction == PathDirection.NotCalculated || currentNode.direction == PathDirection.Vertical)
                            Debug.LogError("found target.cost= " + currentNode.cost);
                        else
                        {
                            Debug.LogError("found target.cost= " + (currentNode.cost + 1));
                        }
                    }
                    break;
                }

                CheckNodeIFUncheckedList(nodes[i, currentNode.coords.columnNumber], unCheckedSet, checkedSet, currentNode, PathDirection.Horizontal);
            }


            unCheckedSet.Remove(currentNode);
            checkedSet.Add(currentNode);

        }

        foreach (var item in checkedSet)
        {
            Debug.Log("Node at  " + item.coords.rowNumber + " : " + item.coords.columnNumber);
        }

        return false;
    }


    private void CheckNodeIFUncheckedList(Node node, List<Node> unCheckedSet, HashSet<Node> checkedSet, Node currentNode, PathDirection direction)
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

            node.direction = direction;
            unCheckedSet.Add(node);

            // Debug.Log(node.coords.rowNumber + " : " + node.coords.columnNumber);

        }
    }


}


