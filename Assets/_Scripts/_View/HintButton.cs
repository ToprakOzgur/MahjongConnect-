﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public void OnHintButtonPressed()
    {
        FindObjectOfType<GameLogicController>().ShowHint();
    }
}
