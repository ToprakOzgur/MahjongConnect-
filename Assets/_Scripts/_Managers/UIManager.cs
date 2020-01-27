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
}
