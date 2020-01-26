using System.Collections.Generic;
public class MaxTwoReturnToPairRule : IRule
{
    public RuleResult Validate(Face[,] faceMatrix, Dictionary<Face, Coords> selectedFaces)
    {
        return new RuleResult(false, RuleResultIdentifiers.MaxTwoReturnToPairsRuleIdentifier);
    }
}
