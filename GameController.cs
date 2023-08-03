using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoardGames;
using TMPro;
using UnityEngine.UIElements;
using System.ComponentModel;

public class GameController : MonoBehaviour
{
    public GameObject Connect4Position;
    public TargetScene CurrentGame;
    public Connect4 Connect4Game;
    public TicTacToe TicTacToeGame;
    public TextMeshPro P1WinCount;
    public TextMeshPro P2WinCount;
    public int P1Wins;
    public int P2Wins;
    private int AccessedRow;
    private int AccessedCol;
    public int BigRow;
    public int BigCol;
    public void GetInput(int col, int row)
    {
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe: TicTacToeInput(col, row); break;
            case TargetScene.Connect4: Connect4Input(col); break;
        }
    }
    public bool isClickable(int col, int row)
    {
        TicTacToeGame.Move(col, row);
        col = AccessedCol;
        row = AccessedRow;
        if (BigRow == AccessedRow)
        {
            if (BigCol == AccessedCol)
            { return true; }
            return false;
        }
        return false;
    }
    public void TicTacToeInput(int col, int row)
    {
        if (TicTacToeGame.CurrentState != GameState.Playing)
        {
            TicTacToeGame = new TicTacToe();
            return;
        }
        if (isClickable(col, row) == true)
        {
            TicTacToeGame.Move(col, row);
            if (TicTacToeGame.CurrentState == GameState.Player1Win) P1Wins++;
            if (TicTacToeGame.CurrentState == GameState.Player2Win) P2Wins++;
            P1WinCount.text = "Player 1 Win Count:\n" + P1Wins.ToString();
            P2WinCount.text = "Player 2 Win Count \n" + P2Wins.ToString();
        }
    }
    public void Connect4Input(int col)
    {
        if (Connect4Game.CurrentState != GameState.Playing)
        {
            Connect4Game = new Connect4();
            return;
        }
        Connect4Game.Move(col);
        if (Connect4Game.CurrentState == GameState.Player1Win) P1Wins++;
        if (Connect4Game.CurrentState == GameState.Player2Win) P2Wins++;
        P1WinCount.text = "Player 1 Win Count:\n" + P1Wins.ToString();
        P2WinCount.text = "Player 2 Win Count \n" + P2Wins.ToString();
    }
    void Start()
    {
        int Current;
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe: TicTacToeGame = new TicTacToe(); break;
            case TargetScene.Connect4: Connect4Game = new Connect4(); break;
        }
        P1Wins = 0;
        P2Wins = 0;
    }

  /*  public void CreateSpaces()
    {
        for (int col = 0; col <7; col++) 
        {
        for (int row = 0; row <6; row++)
            {
                GameObject Current = Instantiate(Connect4Position);
                Space CurrentSpace = Current.GetComponent<Space>();
                CurrentSpace.col = col;
                CurrentSpace.row = row;
                CurrentSpace.Controller = this;
                Current.transform.SetParent(transform);
                Current.transform.localScale = Vector3.one;
                Vector3 pos = new Vector3(-1.44f + .48f * col, -1.2f + .48f * (5 - row), 1);
                Current.transform.localPosition = pos;
  */
                /*
     public int [row, col;
     public Sprite[] DisplayImage;
     public SpriteRenderer DisplayRenderer;
     public GameController Controller;
                 */
            }