using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGameButton : MonoBehaviour
{
    public void OnLeaveButtonPressed()
    {
        GameManager.Instance.ToTitleScene();
    }
}
