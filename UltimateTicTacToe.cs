using System;
namespace TicTacToe
    #region Enumerators
    public enum Position
{
    X, O, Empty;
}
    public enum Turn
{
    Player1, Player2;
}
    public enum GameState
{
    Player1Win, Player2Win, Tie, Playing;
}
#endregion
    #region Helpers
public class Coordinate
{
    #region Fields
    private int _x;
    private int _y;
    #endregion
    #region Properties
    public int x
    {
        get { return _x; }
    }
    public int y
    {
        get { return _y; }
    }
    #endregion
    #region Static Fields
    #endregion
    #endregion
    public class TicTacToe
    {
        #region Fields
        public Position[,] Board;
        public Turn _Player;
        public GameState _CurrentState;
        #endregion
        #region Properties
        public Turn Player
        {
            get { return _Player; }
        }
        public GameState CurrentState
        {
            get { return _CurrentState; }
        }
        #endregion
        #region Constructors
        public TicTacToe()
        {
            Board = new Position[3, 3];
            _Player = Turn.Player1;
            _CurrentState = GameState.Playing;
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    Board[col, row] = Position.Empty;
                }
            }

        }
        public MiniTicTacToe1()
        {
            MiniBoard1 = new Position[3, 3];
            _Player = Turn.Player1;
            _CurrentState = GameState.Playing;
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    Board[col, row] = Position.Empty;
                }
            }

        }
        #endregion
        public void Move(int x, int y)
        {
            if (Board[x, y] != Position.Empty) return;
            if (_CurrentState != GameState.Playing) return;
            Board[x, y] = (Position)Player;
            if (!Winner())
            {
                if (_Player == Turn.Player1) _Player = Turn.Player2;
                else _Player = Turn.Player1;
            }
        }
        public bool Winner()
        {
            if (CheckRow(0)) return true;
            if (CheckRow(1)) return true;
            if (CheckRow(2)) return true;
            if (CheckCol(0)) return true;
            if (CheckCol(1)) return true;
            if (CheckCol(2)) return true;
            if (Diag()) return true;
            if (ReverseDiag()) return true;
            if (isTie()) return false;
            return false;
        }
        public bool isTie()
        {
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (Board[col, row] == Position.Empty) return false;
                }
            }
            _CurrentState = GameState.Tie;
            return true;
        }
        public bool CheckRow(int row)
        {
            Position Winner = Board[0, row];
            if (Winner == Position.Empty) return false;
            if (Board[1, row] != Winner) return false;
            if (Board[2, row] != Winner) return false;
            _CurrentState = (GameState)Player;
            return true;
        }
        public bool CheckCol(int col)
        {
            Position Winner = Board[col, 0];
            if (Winner == Position.Empty) return false;
            if (Board[col, 1] != Winner) return false;
            if (Board[col, 2] != Winner) return false;
            _CurrentState = (GameState)Player;
            return true;
        }
        public bool Diag()
        {
            Position Winner = Board[0, 0];
            if (Winner == Position.Empty) return false;
            if (Board[1, 1] != Winner) return false;
            if (Board[2, 2] != Winner) return false;
            _CurrentState = (GameState)Player;
            return true;
        }
        public bool ReverseDiag()
        {
            Position Winner = Board[0, 2];
            if (Winner == Position.Empty) return false;
            if (Board[1, 1] != Winner) return false;
            if (Board[2, 0] != Winner) return false;
            _CurrentState = (GameState)Player;
            return true;
        }
    }
