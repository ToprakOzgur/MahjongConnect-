using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreater : MonoBehaviour
{
    public FaceController faceController;
    [SerializeField] private LevelLayout[] levels;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform tileHolder;

    private GameLogicController gameLogicController;
    private void Awake()
    {
        gameLogicController = FindObjectOfType<GameLogicController>();
    }
    private void Start()
    {
        var facesMatrix = GenerateLayoutVisual(GameManager.Instance.CurrentLevelNumber - 1);
        gameLogicController.CreateNewGame(facesMatrix);
    }

    //Creates level visuals and face matrix data from leveldata
    public Face[,] GenerateLayoutVisual(int levelNumber)
    {
        int faceCount = GetLevelTilePairsCount(levelNumber);

        var faces = faceController.GetShuffledFaces(faceCount);

        Face[,] facematrix = new Face[levels[levelNumber].columns[0].row.Length, levels[levelNumber].columns.Length];

        var index = 0;

        for (int i = 0; i < facematrix.GetLength(1); i++)
        {
            for (int j = 0; j < facematrix.GetLength(0); j++)
            {
                if (levels[levelNumber].columns[i].row[j])
                {
                    var tileGameobject = Instantiate(tilePrefab.gameObject, tileHolder.transform.position + Vector3.right * j + Vector3.down * i, Quaternion.identity, tileHolder);
                    var tile = tileGameobject.GetComponent<Tile>();
                    tile.AddFaceToTile(faces[index]);
                    tile.AddController(gameLogicController);
                    tile.coords.posX = j;
                    tile.coords.posY = i;
                    facematrix[j, i] = faces[index];
                    gameLogicController.tileViews.Add(tile);
                    index++;
                }

            }
        }
        return facematrix;
    }

    private int GetLevelTilePairsCount(int levelNumber)
    {
        var tileCount = 0;
        foreach (var col in levels[levelNumber].columns)
        {
            foreach (var f in col.row)
            {
                if (f)
                {
                    tileCount++;
                }
            }
        }

        //Tile count should be even
        if (tileCount % 2 != 0)
        {
            Debug.LogError("Level layout is not correct. Tile count should be even number");
        }

        return tileCount / 2;
    }
}
