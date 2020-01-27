using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private GameObject levelCompletedTick;

    private void Start()
    {
        levelCompletedTick.SetActive(GameManager.Instance.GetCurrentLevelIsSccess(levelNumber));
    }
    public void OnPressed(int levelNumber)
    {
        GameManager.Instance.LoadLevelScene(levelNumber);

    }
}
