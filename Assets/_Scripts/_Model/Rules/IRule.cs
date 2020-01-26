using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRule
{
    RuleResult Validate(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces);
}
