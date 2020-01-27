using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelButton : MonoBehaviour
{
    [SerializeField] private GameObject quitGamePopup;
    public void OnExitButtonPressed()
    {
        quitGamePopup.SetActive(!quitGamePopup.activeInHierarchy);

    }
}
