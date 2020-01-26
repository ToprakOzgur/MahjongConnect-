using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region states
    //STATE DESIGN PATTERN for tile views
    [HideInInspector] public ITileState currentState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public MatchingState matchingState;
    [HideInInspector] public SelectedState selectedState;
    [HideInInspector] public ChekingRulesState chekingRulesState;

    #endregion

    [HideInInspector] public GameLogicController controller;

    [SerializeField] private SpriteRenderer faceSpriteRenderer;
    [HideInInspector] public Face face;
    [HideInInspector] public Coords coords;

    public Face Face
    {
        get => face;
        set
        {
            face = value;
            faceSpriteRenderer.sprite = face.sprite;
        }
    }

    private void Awake()
    {
        //initializing states
        idleState = new IdleState(this);
        matchingState = new MatchingState(this);
        selectedState = new SelectedState(this);
        chekingRulesState = new ChekingRulesState(this);
    }
    private void Start()
    {
        currentState = idleState;
    }
    public void AddFaceToTile(Face face)
    {
        this.Face = face;
    }

    public void AddController(GameLogicController controller)
    {
        this.controller = controller;
    }
    private void OnMouseDown()
    {
        currentState.OnMouseDown();
    }

    public void ChangeState(ITileState nexState)
    {
        currentState = nexState;
    }
}

public struct Coords
{
    public int posX;
    public int posY;
}
