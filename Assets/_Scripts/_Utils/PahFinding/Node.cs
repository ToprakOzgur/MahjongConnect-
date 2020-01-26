using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isFull;
    public Coords coords;
    public PathDirection direction;
    public int cost = -1;

    public Node(bool isFull, Coords coords)
    {
        this.isFull = isFull;
        this.coords = coords;
    }
}

public enum PathDirection
{
    Vertical,
    Horizontal
}