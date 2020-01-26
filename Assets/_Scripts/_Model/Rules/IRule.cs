using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRule
{
    RuleResult Validate(Face[,] faceMatrix, List<Face> selectedFaces);
}
