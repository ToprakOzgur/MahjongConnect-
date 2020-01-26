using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelButton : MonoBehaviour
{
    public void OnPressed(int levelNumber)
    {
        GameManager.Instance.LoadLevelScene(levelNumber);

    }
}
