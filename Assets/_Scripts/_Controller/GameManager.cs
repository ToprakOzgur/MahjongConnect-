using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Game Instance Singleton

    private int currentLevelNumber;
    public int CurrentLevelNumber
    {
        get
        {
            return currentLevelNumber;
        }
        private set
        {
            currentLevelNumber = value;
        }

    }
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevelScene(int levelNumber)
    {
        CurrentLevelNumber = levelNumber;

        SceneManager.LoadScene("GamePlay");
    }



}
