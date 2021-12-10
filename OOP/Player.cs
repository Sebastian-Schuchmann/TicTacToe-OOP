using System.Globalization;

namespace OOP;

public abstract class Player
{
    protected FieldValue playerID;

    protected Player(FieldValue playerId)
    {
        playerID = playerId;
    }
    
    public abstract void MakeTurn(Field currentField);
}

public class AIPlayer : Player
{
    public AIPlayer(FieldValue playerId) : base(playerId) { }

    public override void MakeTurn(Field currentField)
    {
        var emptyFields = currentField.GetEmptyFields();
        
        var random = new Random();
        var selection = emptyFields[random.Next(0, emptyFields.Length)];

        currentField.Values[selection] = playerID;
    }
}
public class HumanPlayer : Player
{
    private IInputProvider inputProvider;

    public HumanPlayer(FieldValue playerId) : base(playerId)
    {
        inputProvider = new ConsoleInputProvider();
    }
    
    public override void MakeTurn(Field currentField)
    {
        inputProvider.ReadAndParseInput(out var input, currentField.GetEmptyFields());
        
        for (int x = 0; x < currentField.Values.Length; x++)
        {
            if (currentField.Values[x] == FieldValue.Empty)
            {
                currentField.Values[input] = playerID;
                return;
            }
        }
    }
}