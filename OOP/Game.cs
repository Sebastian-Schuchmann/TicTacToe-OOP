namespace OOP;

public class Game
{
    private Field _field;
    private Player[] _players = new Player[2];
    private int _activePlayerIndex = 0;

    public Game()
    {
        _field = new Field();
        _players[0] = new HumanPlayer(FieldValue.X);
        _players[1] = new HumanPlayer(FieldValue.O);
        //_players[1] = new AIPlayer(FieldValue.O);
        
        Console.WriteLine(_field.ToString());
    }

    public GameState NextTurn()
    {
        var activePlayer = _players[_activePlayerIndex];
        activePlayer.MakeTurn(_field);
        
        Console.Clear();
        Console.WriteLine(_field.ToString());
        
        var gameState = _field.Check();
        SwapActivePlayer();
        
        return gameState;
    }

    private void SwapActivePlayer() => _activePlayerIndex = _activePlayerIndex == 0 ? 1 : 0;
}