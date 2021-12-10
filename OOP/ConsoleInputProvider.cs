namespace OOP;

public class ConsoleInputProvider : IInputProvider
{
    public void ReadAndParseInput(out int selectedField, int[] validInputs)
    {
        Console.WriteLine("Select a Field ");

        var input = Console.ReadLine();
        var couldParse = int.TryParse(input, out var inputAsInt);
        
        if (!couldParse || !validInputs.Contains(inputAsInt))
        {
            Console.WriteLine("Invalid Input");
            ReadAndParseInput(out selectedField, validInputs);
        }
        else
        {
            selectedField = inputAsInt;
        }
    }
}

public interface IInputProvider
{
    void ReadAndParseInput(out int selectedField, int[] validInputs);
}