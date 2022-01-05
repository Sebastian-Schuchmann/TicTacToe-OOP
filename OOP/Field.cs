using System.Text;
namespace OOP;

public class Field
{
    public FieldValue[] Values;
    
    public Field()
    {
        Values = new FieldValue[9];
        
        for (int i = 0; i < 9; i++)
            Values[i] = FieldValue.Empty;
    }
    
    public GameState Check()
    {
        var amountEmptyFields = Values.Count(f => f == FieldValue.Empty);
        if (amountEmptyFields == 0) return GameState.Draw;
        
        var combinations = GenerateCombinations();

        foreach (var combination in combinations)
        {
            var playerXWon =combination.All(val => val == FieldValue.X);
            if (playerXWon) return GameState.PlayerXWon;
            
            var playerOWon =combination.All(val => val == FieldValue.O);
            if (playerOWon) return GameState.PlayerOWon;
        }
        
        return GameState.InProgress;
    }

    private FieldValue[][] GenerateCombinations()
    {
        FieldValue[][] combinations =
        {
            //Horizontal
            new[] {Values[0], Values[1], Values[2]},
            new[] {Values[3], Values[4], Values[5]},
            new[] {Values[6], Values[7], Values[8]},
            //Vertical
            new[] {Values[0], Values[3], Values[6]},
            new[] {Values[1], Values[4], Values[7]},
            new[] {Values[2], Values[5], Values[8]},
            //Diagonal
            new[] {Values[0], Values[4], Values[8]},
            new[] {Values[2], Values[4], Values[6]},
        };
        
        return combinations;
    }
    
    public int[] GetEmptyFields()
    {
        var emptyFields = new List<int>();
        
        for (int i = 0; i < Values.Length; i++)
            if (Values[i] == FieldValue.Empty) emptyFields.Add(i);
        
        return emptyFields.ToArray();
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Field");
        
        for (var i = 0; i < Values.Length; i++)
        {
            string val = Values[i] == FieldValue.Empty ? " " : Values[i].ToString();
            sb.Append(i).Append('[').Append(val).Append("] ");
            if ((i + 1) % 3 == 0) sb.AppendLine();
        }

        return sb.ToString();
    }
}