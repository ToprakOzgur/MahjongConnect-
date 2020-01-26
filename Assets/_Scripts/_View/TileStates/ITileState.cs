using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileState
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnMouseDown();
}
