using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileColorChanger))]
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

    [SerializeField] private SpriteRenderer faceSpriteRenderer;
    [HideInInspector] public GameLogicController controller;
    [HideInInspector] public TileColorChanger tileColorChanger;
    private Face face;

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

        tileColorChanger = GetComponent<TileColorChanger>();
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
        currentState.OnExit();
        currentState = nexState;
        currentState.OnEnter();
    }
}
