using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "LevelLayout", menuName = "LevelLayout", order = 1)]
public class LevelLayout : ScriptableObject
{
    public RowMatrix[] columns;

    [System.Serializable]
    public struct RowMatrix
    {
        public bool[] row;
    }
}





