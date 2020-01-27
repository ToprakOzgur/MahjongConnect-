using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject wonPopup;
    [SerializeField] private GameObject lostPopup;
    [SerializeField] private GameObject hintButtonGameobject;
    [SerializeField] private GameObject exitButtonGameobject;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWonPopup()
    {
        wonPopup.SetActive(true);
        MakeBackgorundUIHidden();
    }
    public void ShowLostPopup()
    {
        lostPopup.SetActive(true);
        MakeBackgorundUIHidden();
    }

    public void MakeBackgorundUIHidden()
    {
        hintButtonGameobject.SetActive(false);
        exitButtonGameobject.SetActive(false);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHighScore(int score)
    {
        highScoreText.text = $"High Score: {score}";
    }
}
