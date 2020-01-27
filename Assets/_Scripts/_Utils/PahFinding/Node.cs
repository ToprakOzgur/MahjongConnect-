using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isFull;
    public Coords coords;
    public PathDirection direction = PathDirection.NotCalculated;
    public int cost = 0;

    public Node(bool isFull, Coords coords)
    {
        this.isFull = isFull;
        this.coords = coords;
    }
}

public enum PathDirection
{
    Vertical,
    Horizontal,
    NotCalculated
}